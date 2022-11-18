using PackIt.Application.Abstractions;
using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;

namespace PackIt.Application.Commands;

public record AddPackingListItem(Guid ListId, string Name, ushort Quantity, bool IsPacked)
    : ICommand;


public sealed class AddPackingListItemHandler : ICommandHandler<AddPackingListItem>
{
    private readonly IPackingListRepository repository;

    public AddPackingListItemHandler(IPackingListRepository repository)
    {
        this.repository = repository;
    }

    public async Task HandleAsync(AddPackingListItem command, CancellationToken cancellationToken)
    {
        var packingList = await repository.GetAsync(command.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{command.ListId}' not found");
        }

        var item = new PackingItem(command.Name, command.Quantity);
        packingList.AddItem(item);

        await repository.UpdateAsync(packingList);
    }
}
