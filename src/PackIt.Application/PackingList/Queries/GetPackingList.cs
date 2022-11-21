using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.DTOs;
using PackIt.Application.PackingList.Shared.Exceptions;

namespace PackIt.Application.PackingList.Queries;

public record GetPackingList(Guid ListId) 
    : IQuery<PackingListDto>;


public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly IPackingListQueryRepository queryRepository;

    public GetPackingListHandler(IPackingListQueryRepository queryRepository)
    {
        this.queryRepository = queryRepository;
    }

    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        var packingList = await queryRepository.TryGetByIdAsync(query.ListId);
        if (packingList is null)
        {
            throw new PackingListNotFoundException($"Packing list with id - '{query.ListId}' not found");
        }

        return packingList;
    }
}
