namespace CommerceCQRS.Services.Shared.Application
{
    public abstract class ApplicationEvent : IApplicationEvent
    {

        public ApplicationEvent(Guid eventId, DateTime occurredOnUtc)
        {
            this.EventId = eventId;
            this.OccurredOnUtc = occurredOnUtc;
        }
        public Guid EventId { get; }
        public DateTime OccurredOnUtc { get; }
    }
}
