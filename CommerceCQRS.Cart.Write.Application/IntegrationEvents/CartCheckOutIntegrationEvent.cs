using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Write.Application.IntegrationEvents
{
    public class CartCheckOutIntegrationEvent(
        Guid eventId,
        DateTime occurredOnUtc,
        Guid cartId,
        Guid userId,
        IEnumerable<CartItemDto> items)
        : ApplicationEvent(eventId, occurredOnUtc)
    {
        public Guid CartId { get; } = cartId;
        public Guid UserId { get; } = userId;
        public IEnumerable<CartItemDto> Items { get; } = items;
    }
}
