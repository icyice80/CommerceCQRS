using CommerceCQRS.Products.Contracts;
using CommerceCQRS.Services.Shared.Application;

namespace CommerceCQRS.Products.Application.GetProductId
{
    public class GetProductResult : OperationResultBase
    {
        
        public GetProductResult() { }

        public GetProductResult(ProductDto product)
        {
            this.Product = product;
        }

        public ProductDto Product { get; set; }

        public GetProductResult ProductNotFound(string message)
        {
            this.Errors.Add(new OperationError(ErrorCode.ProductNotFound, "Product Not Found", message));

            return this;
        }
    }
}
