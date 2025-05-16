using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Domain.Events
{
    public class CartItemAddedDomainEvent : DomainEvent
    {

        public CartItemAddedDomainEvent(Guid cartId, Guid productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }
        public Guid CartId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
    }
}
