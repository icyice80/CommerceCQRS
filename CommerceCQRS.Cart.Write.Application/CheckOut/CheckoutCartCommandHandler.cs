using CommerceCQRS.Cart.Write.Application.AddCartItem;
using CommerceCQRS.Cart.Write.Domain.Interfaces;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Cart.Write.Application.CheckOut
{
    public class CheckoutCartCommandHandler : IRequestHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDomainExceptionTranslator _domainExceptionTranslator;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public CheckoutCartCommandHandler(ICartRepository cartRepository,
            IDomainExceptionTranslator domainExceptionTranslator, IUnitOfWork uow, ILogger<AddItemToCartHandler> logger)
        {
            this._cartRepository = cartRepository;
            this._domainExceptionTranslator = domainExceptionTranslator;
            this._uow = uow;
            this._logger = logger;

        }

        public async Task<CheckoutCartResult> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
                if (cart is null)
                    return new CheckoutCartResult().NotFound();

                cart.Checkout();

                await _uow.SaveChangesAsync(cancellationToken);

            }
            catch (DomainException domainException)
            {
                var result = new CheckoutCartResult();
                result.Errors.Add(this._domainExceptionTranslator.Translate(domainException));
                return result;
            }


            return new CheckoutCartResult(request.CartId);
        }
    }
}
