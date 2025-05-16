using CommerceCQRS.Cart.Write.Domain;
using CommerceCQRS.Cart.Write.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommerceCQRS.Cart.Write.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _context;

        public CartRepository(CartDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Cart?> GetByIdAsync(Guid cartId, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .Include(c => c.Items) // if Cart has a navigation property to items
                .FirstOrDefaultAsync(c => c.Id == cartId, cancellationToken);
        }

        public async Task AddAsync(Domain.Cart cart, CancellationToken cancellationToken)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
        }

        public async Task<Domain.Cart?> GetActiveCartByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId && c.Status == CartStatus.Pending, cancellationToken);
        }


        public Task DeleteAsync(Domain.Cart cart, CancellationToken cancellationToken)
        {
            _context.Carts.Remove(cart);
            return Task.CompletedTask;
        }
    }
}
