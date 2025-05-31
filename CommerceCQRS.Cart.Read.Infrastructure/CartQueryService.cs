using CommerceCQRS.Cart.Read.Application.Interfaces;
using CommerceCQRS.Cart.Read.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CommerceCQRS.Cart.Read.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartDto?> GetActiveCartAsync(Guid? userId, Guid? anonymousId, CancellationToken cancellationToken)
        {
            if (userId == null && anonymousId == null)
                return null;

            var cartQuery = this._context.Carts
                .AsNoTracking()
                .Include(x=>x.Items)
                .Where(c => c.Status == "Pending");

            if (userId != null)
                cartQuery = cartQuery.Where(c => c.UserId == userId);
            else if (anonymousId != null)
                cartQuery = cartQuery.Where(c => c.AnonymousId == anonymousId);

            var cart = await cartQuery
                .Select(c => new CartDto
                {
                    CartId = c.CartId,
                    UserId = c.UserId,
                    AnonymousId = c.AnonymousId,
                    Status = c.Status,
                    Items = c.Items.Select(i => new CartItemDto
                    { 
                        ProductId = i.ProductId,
                        ProductName = i.ProductName,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return cart;
        }
    }
}
