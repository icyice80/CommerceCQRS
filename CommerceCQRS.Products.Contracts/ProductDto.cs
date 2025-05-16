namespace CommerceCQRS.Products.Contracts
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int AvailableQuantity { get; init; }
        public string ImageUrl { get; init; }

        public ProductDto(
            Guid id,
            string name,
            string description,
            decimal price,
            int availableQuantity,
            string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AvailableQuantity = availableQuantity;
            ImageUrl = imageUrl;
        }
    }
}
