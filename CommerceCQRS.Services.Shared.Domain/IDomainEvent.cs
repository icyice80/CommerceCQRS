namespace CommerceCQRS.Services.Shared.Domain
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
        DateTime OccurredOn { get; }
    }
}
