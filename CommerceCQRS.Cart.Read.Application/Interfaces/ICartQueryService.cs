using CommerceCQRS.Cart.Read.Contracts;

namespace CommerceCQRS.Cart.Read.Application.Interfaces
{
    public interface ICartQueryService
    {
        Task<CartDto?> GetActiveCartAsync(Guid? userId, Guid? anonymousId, CancellationToken cancellationToken);
    }
}
