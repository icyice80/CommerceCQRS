using CommerceCQRS.Cart.Write.Application.AddCartItem;
using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.CheckOut
{
    public class CheckoutCartResult : OperationResultBase
    {
        private const string CartError = "Cart Error";
        public Guid CartId { get; }

        public CheckoutCartResult()
        {
        }

        public CheckoutCartResult(Guid cartId)
        {
            CartId = cartId;
        }

        public CheckoutCartResult NotFound()
        {
            this.Errors.Add(new OperationError(ErrorCode.NotFound, CartError, "Invalid Cart"));
            return this;
        }
    }
}
