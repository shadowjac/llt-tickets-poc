using LLT.PrintTickets.PoC.Domain.Buyers;
using LLT.PrintTickets.PoC.Domain.Buyers.Repositories;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Repositories;

internal sealed class BuyerRepository(ApplicationDbContext dbContext) : Repository<Buyer>(dbContext), IBuyerRepository;