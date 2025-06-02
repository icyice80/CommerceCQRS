namespace CommerceCQRS.Cart.Write.Application
{
    public class CartItemDto
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public CartItemDto(Guid productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }
    }
}
