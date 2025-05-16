using MediatR;

namespace CommerceCQRS.Cart.Write.Application.AddCartItem
{
    public record AddItemToCartCommand(Guid? CartId, Guid ProductId, int Quantity, Guid? UserId, Guid? AnonymousId) : IRequest<AddCartItemResult>; 
}
