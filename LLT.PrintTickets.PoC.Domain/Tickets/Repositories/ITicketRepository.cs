namespace LLT.PrintTickets.PoC.Domain.Tickets.Repositories;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Ticket ticket, CancellationToken cancellationToken = default);
    Task PrintAsync(Guid id, CancellationToken cancellationToken = default);
}