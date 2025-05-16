namespace CommerceCQRS.Services.Shared.Domain
{
    public abstract class Entity<TId>
    {
        protected Entity(TId id)
        {
            this.Id = id;
        }

        public TId Id { get; init; }
    }
}
