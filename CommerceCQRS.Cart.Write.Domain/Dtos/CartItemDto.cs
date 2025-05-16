namespace CommerceCQRS.Cart.Write.Domain.Dtos
{
    public record CartItemDto(Guid ProductId, int Quantity);
}
