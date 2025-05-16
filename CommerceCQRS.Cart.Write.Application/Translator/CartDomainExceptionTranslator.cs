using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Application.Translator
{
    public class CartDomainExceptionTranslator : IDomainExceptionTranslator
    {
        private const string CartError = "Cart Error";

        private static readonly IReadOnlyDictionary<Domain.Exception.ErrorCode, Func<DomainException, OperationError>> _map =
            new Dictionary<Domain.Exception.ErrorCode, Func<DomainException, OperationError>>
            {
                [Domain.Exception.ErrorCode.EmptyCart] = ex => new(ErrorCode.EmptyCart, CartError, ex.Message),
                [Domain.Exception.ErrorCode.InvalidCartStatus] = ex => new(ErrorCode.InvalidCartStatus, CartError, ex.Message),
                [Domain.Exception.ErrorCode.InvalidQuantity] = ex => new(ErrorCode.InvalidQuantity, CartError, ex.Message),
                [Domain.Exception.ErrorCode.NotFound] = ex => new(ErrorCode.NotFound, CartError, "Item cannot be found")
            };

        public OperationError Translate(DomainException exception)
        {
            if (_map.TryGetValue((Domain.Exception.ErrorCode)exception.ErrorCode, out var translator))
            {
                return translator(exception);
            }

            return new OperationError(ErrorCode.Unknown, CartError, "An unexpected error occurred.");
        }
    }
}
