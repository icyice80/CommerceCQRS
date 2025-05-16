using CommerceCQRS.Cart.Write.Domain.Dtos;

namespace CommerceCQRS.Cart.Write.Domain
{
    public static class CartItemMapper
    {
        public static CartItemDto ToDto(CartItem item) =>
            new CartItemDto(item.ProductId, item.Quantity);

        public static List<CartItemDto> ToDtoList(IEnumerable<CartItem> items)
        {
            return items.Select(ToDto).ToList();
        }
    }
}
