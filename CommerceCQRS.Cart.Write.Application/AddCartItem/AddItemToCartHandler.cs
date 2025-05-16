using CommerceCQRS.Cart.Write.Domain.Interfaces;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Cart.Write.Application.AddCartItem
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, AddCartItemResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDomainExceptionTranslator _domainExceptionTranslator;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public AddItemToCartHandler(ICartRepository cartRepository,IDomainExceptionTranslator domainExceptionTranslator,  IUnitOfWork uow, ILogger<AddItemToCartHandler> logger)
        {
            this._cartRepository = cartRepository;
            this._domainExceptionTranslator = domainExceptionTranslator;
            this._uow = uow;
            this._logger = logger;
        }

        public async Task<AddCartItemResult> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            Domain.Cart? cart = null;

            try
            {
                if (request.CartId.HasValue)
                {
                    cart = await this._cartRepository.GetByIdAsync(request.CartId.Value, cancellationToken);
                }

                if (cart is null)
                {
                    // Determine the owner of the cart: either userid or anonymous 
                    Guid? ownerId = request.UserId ?? request.AnonymousId;

                    if (!ownerId.HasValue)
                    {
                        return new AddCartItemResult().InvalidUserIdOrAnonymousId();
                    }

                    cart = new Domain.Cart(Guid.NewGuid(), ownerId.Value);

                    cart.AddItem(request.ProductId, request.Quantity);
                    await _cartRepository.AddAsync(cart, cancellationToken);
                }
                else
                {
                    cart.AddItem(request.ProductId, request.Quantity);
                }

                await this._uow.SaveChangesAsync(cancellationToken);
            }
            catch (DomainException domainException)
            {
                var result = new AddCartItemResult();
                result.Errors.Add(this._domainExceptionTranslator.Translate(domainException));
                return result;
            }


            return new AddCartItemResult(cart.Id);
        }
    }
}
