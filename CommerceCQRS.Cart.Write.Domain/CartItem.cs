using CommerceCQRS.Cart.Write.Domain.Exception;
using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Domain
{
    public class CartItem
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public CartItem(Guid productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException((int)ErrorCode.InvalidQuantity, "Quantity cant be updated to 0 or less");
            }

            this.Quantity = quantity;
        }
    }
}
