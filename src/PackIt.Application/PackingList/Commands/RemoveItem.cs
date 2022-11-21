using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.Exceptions;
using PackIt.Domain.Abstractions;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Commands;

public record RemoveItem(Guid ListId, string Name)
    : ICommand;


public class RemoveItemHandler : ICommandHandler<RemoveItem>
{
    private readonly IPackingListDomainRepository domainRepository;

    public RemoveItemHandler(IPackingListDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task HandleAsync(RemoveItem command, CancellationToken cancellationToken)
    {
        var packingList = await domainRepository.GetAsync(command.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{command.ListId}' not found");
        }

        packingList.RemoveItem(command.Name);
        await domainRepository.UpdateAsync(packingList);
    }
}