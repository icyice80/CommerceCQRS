using CommerceCQRS.Products.Contracts;

namespace CommerceCQRS.Products.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken);

        Task<IEnumerable<ProductSummaryDto>> GetAllProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

        Task<int> GetTotalCountAsync(CancellationToken cancellationToken);
    }
}
