using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.MergeCart
{
    public class MergeCartResult : OperationResultBase
    {
        public Guid? CartId { get; }

        public MergeCartResult(Guid? cartId = null) => CartId = cartId;

    }
}
