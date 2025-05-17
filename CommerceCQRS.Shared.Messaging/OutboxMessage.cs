namespace CommerceCQRS.Services.Shared.Messaging
{
    public record OutboxMessage
    {
        public Guid Id { get; init; }
        public DateTime OccurredOn { get; init; }
        public string Type { get; init; } = null!;
        public string Content { get; init; } = null!;
        public bool Processed { get; init; }
        public DateTime? ProcessedOn { get; init; }
    }
}
