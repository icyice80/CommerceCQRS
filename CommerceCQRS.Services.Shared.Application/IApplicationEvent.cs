namespace CommerceCQRS.Services.Shared.Application
{
    public interface IApplicationEvent
    {
        Guid EventId { get; }
        DateTime OccurredOnUtc { get; }
    }
}
