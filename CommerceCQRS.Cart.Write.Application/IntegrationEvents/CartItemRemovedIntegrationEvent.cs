using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.IntegrationEvents
{
    public class CartItemRemovedIntegrationEvent: ApplicationEvent
    {
        public CartItemRemovedIntegrationEvent(Guid eventId, DateTime occurredOnUtc,  Guid cartId, Guid productId): base(eventId, occurredOnUtc)
        {
            CartId = cartId;
            ProductId = productId;
        }
        public Guid CartId { get; }
        public Guid ProductId { get; }
    }
}
