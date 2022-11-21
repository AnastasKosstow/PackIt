using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.Exceptions;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Commands;

public record DeletePackingList(Guid ListId, string Name)
    : ICommand;


public class DeletePackingListHandler : ICommandHandler<DeletePackingList>
{
    private readonly IPackingListDomainRepository domainRepository;

    public DeletePackingListHandler(IPackingListDomainRepository domainRepository)
    {
        this.domainRepository = domainRepository;
    }

    public async Task HandleAsync(DeletePackingList command, CancellationToken cancellationToken)
    {
        var packingList = await domainRepository.GetAsync(command.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{command.ListId}' not found");
        }

        await domainRepository.DeleteAsync(packingList);
    }
}
