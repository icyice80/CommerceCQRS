using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.AddCartItem
{
    public class AddCartItemResult : OperationResultBase
    {
        private const string CartError = "Cart Error";
        public Guid? CartId { get; }

        public AddCartItemResult()
        {
        }

        public AddCartItemResult(Guid cartId)
        {
            CartId = cartId;
        }

        public AddCartItemResult InvalidUserIdOrAnonymousId()
        {
            this.Errors.Add(new OperationError(ErrorCode.MissingUserIdOrAnonymousId, CartError, "User Id is missing"));
            return this;
        }
    }
}
