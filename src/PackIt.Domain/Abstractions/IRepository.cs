namespace PackIt.Domain.Abstractions;

public interface IRepository<in TEntity> where TEntity : IAggregateRoot
{
    Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
}
