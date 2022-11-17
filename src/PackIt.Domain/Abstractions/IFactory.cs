namespace PackIt.Domain.Abstractions;

public interface IFactory<out TEntity> where TEntity : IAggregateRoot
{
    TEntity Build();
}
