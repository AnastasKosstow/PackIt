using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.Exceptions;
using PackIt.Domain.Repositories;
using PackIt.Domain.ValueObjects;

namespace PackIt.Application.PackingList.Commands;

public record AddPackingListItem(Guid ListId, string Name, ushort Quantity)
    : ICommand;


public sealed class AddPackingListItemHandler : ICommandHandler<AddPackingListItem>
{
    private readonly IPackingListDomainRepository repository;

    public AddPackingListItemHandler(IPackingListDomainRepository repository)
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
