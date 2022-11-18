using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Abstractions;

namespace PackIt.Application.Dispatcher;

internal sealed class InMemoryCommandDispatcher : ICommandDispacher
{
    private readonly IServiceProvider serviceProvider;

    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        =>
        this.serviceProvider = serviceProvider;


    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : class, ICommand
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command, cancellationToken);
    }
}
