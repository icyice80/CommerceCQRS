using CommerceCQRS.Cart.Read.Application.Interfaces;
using MediatR;

namespace CommerceCQRS.Cart.Read.Application.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, GetCartResult>
    {
        private readonly ICartQueryService _cartRepository;

        public GetCartQueryHandler(ICartQueryService cartRepository)
        {
            this._cartRepository = cartRepository;
        }
        public async Task<GetCartResult> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await this._cartRepository.GetActiveCartAsync(request.UserId, request.AnonymousId,
                cancellationToken);

            return new GetCartResult(cart);
        }
    }
}
