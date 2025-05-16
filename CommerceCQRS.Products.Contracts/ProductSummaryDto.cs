namespace CommerceCQRS.Products.Contracts
{
    public record ProductSummaryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string ThumbnailUrl { get; init; }

        public ProductSummaryDto(
            Guid id,
            string name,
            decimal price,
            string thumbnailUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            ThumbnailUrl = thumbnailUrl;
        }
    }
}
