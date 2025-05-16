using MediatR;

namespace CommerceCQRS.Cart.Write.Application.RemoveCartItem
{
    public record RemoveCartItemCommand(Guid cartId, Guid productId) : IRequest<RemoveCartItemResult>;
}
