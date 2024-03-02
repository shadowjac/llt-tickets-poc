using LLT.PrintTickets.PoC.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LLT.PrintTickets.PoC.Infrastructure.Persistence.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    
    protected  DbSet<T> Set => DbContext.Set<T>();

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<T>().SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<T>().AddAsync(entity, cancellationToken);
    }
}