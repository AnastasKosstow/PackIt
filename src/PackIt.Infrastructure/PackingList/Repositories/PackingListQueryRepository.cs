using Mapster;
using Microsoft.EntityFrameworkCore;
using PackIt.Application.PackingList;
using PackIt.Application.PackingList.Shared.DTOs;
using PackIt.Infrastructure.Abstractions;
using PackIt.Infrastructure.PackingList.EF;

namespace PackIt.Infrastructure.PackingList.Repositories;

internal sealed class PackingListQueryRepository : Repository<PackingListDbContext, Domain.Entities.PackingList>, 
    IPackingListQueryRepository
{
    public PackingListQueryRepository(PackingListDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<PackingListDto>> SearchAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<PackingListDto> TryGetByIdAsync(Guid id)
    {
        var packingListModel = await Context.PackingLists
            .Include("items")
            .SingleOrDefaultAsync(pl => pl.Id == id);

        var result = packingListModel.Adapt<PackingListDto>();
        return result;
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        bool exists = await Context.PackingLists
            .AnyAsync(pl => pl.Name.Value == name);
        
        return exists;
    }
}
