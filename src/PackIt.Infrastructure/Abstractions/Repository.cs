using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Abstractions;

namespace PackIt.Infrastructure.Abstractions;

public abstract class Repository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IAggregateRoot
{
    protected TDbContext Context { get; private set; }

    protected Repository(TDbContext context)
    {
        this.Context = context;
    }

    public async Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
