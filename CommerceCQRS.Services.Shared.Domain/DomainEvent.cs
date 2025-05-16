namespace CommerceCQRS.Services.Shared.Domain
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.OccurredOn = DateTime.Now;
        }

        public Guid EventId { get; }
        public DateTime OccurredOn { get; }
    }
}
