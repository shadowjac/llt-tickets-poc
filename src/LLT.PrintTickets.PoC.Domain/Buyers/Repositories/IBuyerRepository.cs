namespace LLT.PrintTickets.PoC.Domain.Buyers.Repositories;

public interface IBuyerRepository
{
    Task<Buyer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}