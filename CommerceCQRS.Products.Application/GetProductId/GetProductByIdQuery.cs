using MediatR;

namespace CommerceCQRS.Products.Application.GetProductId
{
    public record GetProductByIdQuery(int ProductId) : IRequest<GetProductResult>;
}
