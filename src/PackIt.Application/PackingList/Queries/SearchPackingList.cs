using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.Shared.DTOs;

namespace PackIt.Application.PackingList.Queries;

public record SearchPackingList(string Name) : IQuery<PackingListDto>;


public sealed class SearchPackingListHandler : IQueryHandler<SearchPackingList, PackingListDto>
{
    public Task<PackingListDto> HandleAsync(SearchPackingList query)
    {
        throw new NotImplementedException();
    }
}