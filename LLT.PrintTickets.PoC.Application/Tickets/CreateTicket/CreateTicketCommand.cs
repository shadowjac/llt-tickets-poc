using LLT.PrintTickets.PoC.Application.Abstractions.Messaging;

namespace LLT.PrintTickets.PoC.Application.Tickets.CreateTicket;

public record CreateTicketCommand(
    Guid OwnerId,
    DateOnly MatchDate,
    TimeOnly MatchTime,
    string Home,
    string Visitor,
    decimal Price,
    DateTime CreatedAt) : ICommand<Guid>;