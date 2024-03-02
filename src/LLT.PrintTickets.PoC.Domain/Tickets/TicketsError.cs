using LLT.PrintTickets.PoC.Domain.Abstractions;

namespace LLT.PrintTickets.PoC.Domain.Tickets;

public static class TicketsError
{
    public static Error GeneralError(string error) => new Error(
        "Tickets.GeneralError",
        error);
}