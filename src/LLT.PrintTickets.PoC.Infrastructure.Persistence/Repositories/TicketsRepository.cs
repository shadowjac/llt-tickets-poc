using LLT.PrintTickets.PoC.Domain.Tickets;
using LLT.PrintTickets.PoC.Domain.Tickets.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Repositories;

internal sealed class TicketsRepository : Repository<Ticket>, ITicketRepository
{
    public TicketsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}