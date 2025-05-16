using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.RemoveCartItem
{
    public class RemoveCartItemResult : OperationResultBase
    {
        private const string CartError = "Cart Error";

        public RemoveCartItemResult()
        {
        }

        public RemoveCartItemResult(Guid cartId)
        {
            this.CartId = cartId;
        }

        public Guid CartId { get; }

        public RemoveCartItemResult NotFound()
        {
            this.Errors.Add(new OperationError(ErrorCode.NotFound, CartError, "Invalid Cart"));
            return this;
        }
    }
}
