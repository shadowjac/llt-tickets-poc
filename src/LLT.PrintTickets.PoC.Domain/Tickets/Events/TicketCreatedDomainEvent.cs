using LLT.PrintTickets.PoC.Domain.Abstractions;

namespace LLT.PrintTickets.PoC.Domain.Tickets.Events;

public record TicketCreatedDomainEvent(Guid TicketId): IDomainEvent;