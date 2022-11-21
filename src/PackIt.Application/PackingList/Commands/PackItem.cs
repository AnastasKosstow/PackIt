using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.Exceptions;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Commands;

public record PackItem(Guid ListId, string Name)
    : ICommand;


public class PackItemHandler : ICommandHandler<PackItem>
{
    private readonly IPackingListDomainRepository domainRepository;

    public PackItemHandler(IPackingListDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task HandleAsync(PackItem command, CancellationToken cancellationToken)
    {
        var packingList = await domainRepository.GetAsync(command.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{command.ListId}' not found");
        }

        packingList.PackItem(command.Name);
        await domainRepository.UpdateAsync(packingList);
    }
}
