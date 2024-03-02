using Application.Abstractions.Clock;

namespace LLT.PrintTickets.PoC.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}