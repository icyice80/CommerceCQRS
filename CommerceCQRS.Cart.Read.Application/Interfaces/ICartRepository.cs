using CommerceCQRS.Cart.Read.Contracts;

namespace CommerceCQRS.Cart.Read.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<CartDto?> GetActiveCartAsync(Guid? userId, Guid? anonymousId, CancellationToken cancellationToken);
    }
}
