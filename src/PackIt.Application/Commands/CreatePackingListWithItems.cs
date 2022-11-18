using PackIt.Application.Abstractions;

namespace PackIt.Application.Commands;

public record CreatePackingListWithItems(Guid id, string name, string country, string city) : ICommand
{
}

public class CreatePackingListWithItemsHandler : ICommandHandler<CreatePackingListWithItems>
{
    public Task HandleAsync(CreatePackingListWithItems command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}