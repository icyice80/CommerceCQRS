namespace CommerceCQRS.Cart.Read.Contracts
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? AnonymousId { get; set; }
        public string Status { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
    }
}
