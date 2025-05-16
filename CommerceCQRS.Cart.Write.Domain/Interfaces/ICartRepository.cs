namespace CommerceCQRS.Cart.Write.Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetByIdAsync(Guid cartId, CancellationToken cancellationToken);

        Task AddAsync(Cart cart, CancellationToken cancellationToken);

        Task<Cart?> GetActiveCartByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        Task DeleteAsync(Cart cart, CancellationToken cancellationToken);
    }
}
