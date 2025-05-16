namespace CommerceCQRS.Cart.Read.Contracts
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal UnitPrice { get; set; } 
        public int Quantity { get; set; }
    }
}
