using CommerceCQRS.Products.Application.Interfaces;
using CommerceCQRS.Services.Shared.Application;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CommerceCQRS.Products.Application.GetProductId
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery,GetProductResult>
    {
        private readonly IProductQueryService _productRepository;
        private readonly ILogger<GetProductByIdHandler> _logger;

        public GetProductByIdHandler(IProductQueryService productRepository, ILogger<GetProductByIdHandler> logger)
        {
            this._productRepository = productRepository;
            this._logger = logger;
        }
        public async Task<GetProductResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productDto = await this._productRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
           

            if (productDto == null)
            {
                var result = new GetProductResult();
                result.Errors.Add(new OperationError(ErrorCode.ProductNotFound, "Product Not Found", $"Product: {request.ProductId} does not exist"));
            }

            return new GetProductResult(productDto);
        }
    }
}
