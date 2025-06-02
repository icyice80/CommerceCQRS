using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Domain.Events
{
    public class CartCheckedOutDomainEvent : DomainEvent
    {
        public CartCheckedOutDomainEvent(
            Guid cartId,
            Guid userId,
            IEnumerable<CartItem> items)
        {
            this.CartId = cartId;
            this.UserId = userId;
            this.Items = items;
            
        }
        public Guid CartId { get; }
        public Guid UserId { get; }
        public IEnumerable<CartItem> Items { get; }
    }
}
