using CommerceCQRS.Cart.Write.Application.IntegrationEvents;
using CommerceCQRS.Cart.Write.Domain.Events;
using CommerceCQRS.Services.Shared.Application;
using CommerceCQRS.Services.Shared.Domain;

namespace CommerceCQRS.Cart.Write.Application.Translator
{
    public static class DomainEventMapper
    {
        public static IApplicationEvent? ToIntegrationEvent(IDomainEvent domainEvent)
        {
            return domainEvent switch
            {
                CartCheckedOutDomainEvent e => new CartCheckOutIntegrationEvent(e.EventId,e.OccurredOnUtc, e.CartId, e.UserId, e.Items.Select(x=>new CartItemDto(x.ProductId,x.Quantity))),

                CartItemAddedDomainEvent e => new CartItemAddedIntegrationEvent( e.EventId, e.OccurredOnUtc, e.CartId,e.ProductId,e.Quantity),

                CartItemRemovedDomainEvent e => new CartItemRemovedIntegrationEvent(e.EventId, e.OccurredOnUtc, e.CartId, e.ProductId),
                // add other mappings here

                _ => null
            };
        }
    }
}
