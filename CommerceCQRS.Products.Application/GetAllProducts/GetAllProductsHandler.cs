using CommerceCQRS.Products.Application.Interfaces;
using CommerceCQRS.Products.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Products.Application.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetPagedProductsResult<ProductSummaryDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsHandler> _logger;
        public GetAllProductsHandler(IProductRepository productRepository, ILogger<GetAllProductsHandler> logger)
        {
            this._productRepository = productRepository;
            this._logger = logger;
        }

        public async Task<GetPagedProductsResult<ProductSummaryDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await this._productRepository.GetTotalCountAsync(cancellationToken);
            var products = await this._productRepository.GetAllProductsAsync(request.PageNumber, request.PageSize, cancellationToken);

            return new GetPagedProductsResult<ProductSummaryDto>
            {
                Items = products.ToList().AsReadOnly(), TotalCount = totalCount, PageNumber = request.PageNumber, PageSize = request.PageSize
            };
        }
    }
}
