using CommerceCQRS.Products.Application.Interfaces;
using CommerceCQRS.Products.Contracts;

namespace CommerceCQRS.Products.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductSummaryDto>> GetAllProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCountAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
