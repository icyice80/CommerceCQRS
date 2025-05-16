using CommerceCQRS.Products.Contracts;
using MediatR;

namespace CommerceCQRS.Products.Application.GetAllProducts
{
    public record GetAllProductsQuery(int PageNumber, int PageSize) : IRequest<GetPagedProductsResult<ProductSummaryDto>>;
}
