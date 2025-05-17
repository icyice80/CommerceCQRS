namespace CommerceCQRS.Services.Shared.Messaging
{
    public record OutboxMessage
    {
        public Guid Id { get; init; }
        public DateTime OccurredOn { get; init; }
        public string Type { get; init; } = null!;
        public string Content { get; init; } = null!;
        public DateTime? ProcessedOnUtc { get; set; }

        public DateTime? LockedUntilUtc { get; set; }
    }
}
