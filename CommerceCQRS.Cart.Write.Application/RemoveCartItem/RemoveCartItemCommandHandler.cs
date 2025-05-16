using CommerceCQRS.Cart.Write.Application.AddCartItem;
using CommerceCQRS.Cart.Write.Domain.Interfaces;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Cart.Write.Application.RemoveCartItem
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, RemoveCartItemResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDomainExceptionTranslator _domainExceptionTranslator;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public RemoveCartItemCommandHandler(ICartRepository cartRepository, IDomainExceptionTranslator domainExceptionTranslator, IUnitOfWork uow, ILogger<AddItemToCartHandler> logger)
        {
            this._cartRepository = cartRepository;
            this._domainExceptionTranslator = domainExceptionTranslator;
            this._uow = uow;
            this._logger = logger;
        }
        public async Task<RemoveCartItemResult> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            var result = new RemoveCartItemResult();

            var cart = await this._cartRepository.GetByIdAsync(request.cartId, cancellationToken);

            if (cart is null)
                return new RemoveCartItemResult().NotFound();

            try
            {
                cart.RemoveItem(request.productId);
                await _uow.SaveChangesAsync(cancellationToken);
                return new RemoveCartItemResult(cart.Id);
            }
            catch (DomainException domainException)
            {
                result.Errors.Add(this._domainExceptionTranslator.Translate(domainException));
                return result;
            }
        }
    }
}
