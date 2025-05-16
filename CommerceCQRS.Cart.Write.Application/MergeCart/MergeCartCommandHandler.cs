using CommerceCQRS.Cart.Write.Application.AddCartItem;
using CommerceCQRS.Cart.Write.Domain.Interfaces;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Cart.Write.Application.MergeCart
{
    public class MergeCartCommandHandler : IRequestHandler<MergeCartCommand, MergeCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDomainExceptionTranslator _domainExceptionTranslator;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<AddItemToCartHandler> _logger;

        public MergeCartCommandHandler(ICartRepository cartRepository,
            IDomainExceptionTranslator domainExceptionTranslator, IUnitOfWork uow, ILogger<AddItemToCartHandler> logger)
        {
            this._cartRepository = cartRepository;
            this._domainExceptionTranslator = domainExceptionTranslator;
            this._uow = uow;
            this._logger = logger;

        }

        public async Task<MergeCartResult> Handle(MergeCartCommand request, CancellationToken cancellationToken)
        {
            var result = new MergeCartResult();

            var anonymousCart = await this._cartRepository.GetActiveCartByUserIdAsync(request.AnonymousId, cancellationToken);
            var userCart = await this._cartRepository.GetActiveCartByUserIdAsync(request.UserId, cancellationToken);

            if (anonymousCart == null)
                return new MergeCartResult(userCart?.Id); // No anonymous cart to merge

            if (userCart == null)
            {
                anonymousCart.AssignToUser(request.UserId);
                await this._uow.SaveChangesAsync(cancellationToken);
                return new MergeCartResult(anonymousCart.Id);
            }

            try
            {
                userCart.MergeWith(anonymousCart);
                await this._cartRepository.DeleteAsync(anonymousCart,cancellationToken);
                await this._uow.SaveChangesAsync(cancellationToken);
                return new MergeCartResult(userCart.Id);
            }
            catch (DomainException domainException)
            {
                result.Errors.Add(this._domainExceptionTranslator.Translate(domainException));
                return result;
            }
        }
    }
}
