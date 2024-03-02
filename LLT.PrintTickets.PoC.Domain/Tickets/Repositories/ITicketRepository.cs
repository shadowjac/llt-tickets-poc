using System.Collections.ObjectModel;

namespace LLT.PrintTickets.PoC.Domain.Tickets.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default);
}