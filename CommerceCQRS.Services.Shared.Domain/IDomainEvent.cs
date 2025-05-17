﻿namespace CommerceCQRS.Services.Shared.Domain
{
    public interface IDomainEvent
    {
        Guid EventId { get; }
        DateTime OccurredOnUtc { get; }
    }
}
