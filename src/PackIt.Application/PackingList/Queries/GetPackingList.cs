using PackIt.Application.Abstractions;
using PackIt.Application.PackingList.DTOs;
using PackIt.Domain.Repositories;

namespace PackIt.Application.PackingList.Queries;

public class GetPackingList : IQuery<PackingListDto>
{
    public Guid Id { get; set; }
}

public class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly IPackingListRepository repository;

    public GetPackingListHandler(IPackingListRepository repository)
    {
        this.repository = repository;
    }

    public async Task<PackingListDto> HandleAsync(GetPackingList query)
    {
        var packingList = await repository.GetAsync(query.Id);
        return new PackingListDto(packingList.Id, "");
    }
}
