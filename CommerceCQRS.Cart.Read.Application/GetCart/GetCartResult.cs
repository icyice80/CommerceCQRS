using CommerceCQRS.Cart.Read.Contracts;
using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Cart.Read.Application.GetCart
{
    public class GetCartResult : OperationResultBase
    {
        public GetCartResult(CartDto? dto)
        {
            this.Cart = dto;
        }

        public CartDto? Cart { get; init; }
    }
}
