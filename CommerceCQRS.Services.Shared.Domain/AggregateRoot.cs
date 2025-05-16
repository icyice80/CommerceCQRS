namespace CommerceCQRS.Services.Shared.Domain
{
    public class AggregateRoot<T>: Entity<T>, IAggregateRoot
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public AggregateRoot(T id) : base(id)
        {
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => this._domainEvents.AsReadOnly();

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
           this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            this._domainEvents.Clear();
        }
    }
}
