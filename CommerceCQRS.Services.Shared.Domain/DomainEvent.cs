namespace CommerceCQRS.Services.Shared.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.OccurredOnUtc = DateTime.UtcNow;
        }

        public Guid EventId { get; }
        public DateTime OccurredOnUtc { get; }
    }
}
