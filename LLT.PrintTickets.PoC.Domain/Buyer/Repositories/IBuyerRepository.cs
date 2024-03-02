namespace LLT.PrintTickets.PoC.Domain.Buyer.Repositories;

public interface IBuyerRepository
{
    Task<Buyer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}