using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Products.Application.GetAllProducts
{
    public class GetPagedProductsResult<T> : OperationResultBase
    {
        public IReadOnlyCollection<T> Items { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalCount { get; set; }
    }
}
