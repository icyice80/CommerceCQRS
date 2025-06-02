using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.IntegrationEvents
{
    public class CartItemAddedIntegrationEvent(
        Guid eventId,
        DateTime occurredOnUtc,
        Guid cartId,
        Guid productId,
        int quantity)
        : ApplicationEvent(eventId, occurredOnUtc)
    {
        public Guid CartId { get; } = cartId;
    public Guid ProductId { get; } = productId;
    public int Quantity { get; } = quantity;
    }
}
