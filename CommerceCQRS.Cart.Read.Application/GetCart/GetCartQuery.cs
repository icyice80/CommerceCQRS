using System.Net;
using MediatR;

namespace CommerceCQRS.Cart.Read.Application.GetCart
{
    public record GetCartQuery(Guid? UserId, Guid? AnonymousId) : IRequest<GetCartResult>;
}
