using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Abstractions;

namespace PackIt.Application.Dispatcher;

internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider serviceProvider;

    public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        =>
        this.serviceProvider = serviceProvider;

    public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken) 
        where TResult : class
    {
        using var scope = serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>)
            .MakeGenericType(query.GetType(), typeof(TResult));

        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>)handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
            .Invoke(handler, new[] { query });
    }
}
