namespace PackIt.Shared.Abstractions;

public interface IFactory<out TEntity>
{
    TEntity Build();
}
