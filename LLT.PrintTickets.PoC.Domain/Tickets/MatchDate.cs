namespace LLT.PrintTickets.PoC.Domain.Tickets;

public sealed record MatchDate(
    DateOnly Day,
    TimeOnly Time);
