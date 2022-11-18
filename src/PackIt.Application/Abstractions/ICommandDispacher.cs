namespace PackIt.Application.Abstractions;

public interface ICommandDispacher
{
    Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) 
        where TCommand : class, ICommand;
}
