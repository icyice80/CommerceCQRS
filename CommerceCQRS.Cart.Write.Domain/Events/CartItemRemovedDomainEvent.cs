using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Domain.Events
{
    public class CartItemRemovedDomainEvent : DomainEvent
    {
        public CartItemRemovedDomainEvent(Guid cartId, Guid productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
        public Guid CartId { get; }
        public Guid ProductId { get; }
    }
}
