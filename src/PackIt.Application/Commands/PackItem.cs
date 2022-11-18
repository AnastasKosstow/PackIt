using PackIt.Application.Abstractions;
using PackIt.Application.Exceptions;
using PackIt.Domain.Repositories;

namespace PackIt.Application.Commands;

public record PackItem(Guid ListId, string Name)
    : ICommand;


public class PackItemHandler : ICommandHandler<PackItem>
{
    private readonly IPackingListRepository repository;

    public PackItemHandler(IPackingListRepository repository)
    {
        this.repository = repository;
    }

    public async Task HandleAsync(PackItem command, CancellationToken cancellationToken)
    {
        var packingList = await repository.GetAsync(command.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{command.ListId}' not found");
        }

        packingList.PackItem(command.Name);
        await repository.UpdateAsync(packingList);
    }
}
