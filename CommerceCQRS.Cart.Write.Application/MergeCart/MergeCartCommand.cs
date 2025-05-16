using MediatR;

namespace CommerceCQRS.Cart.Write.Application.MergeCart
{
    public record MergeCartCommand(Guid UserId, Guid AnonymousId) : IRequest<MergeCartResult>;
}
