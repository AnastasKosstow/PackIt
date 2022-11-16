namespace PackIt.Domain.Abstractions;

public interface IFactory<out TEntity>
{
    TEntity Build();
}
