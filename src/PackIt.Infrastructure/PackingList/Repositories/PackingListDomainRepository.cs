using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Repositories;
using PackIt.Infrastructure.Abstractions;
using PackIt.Infrastructure.PackingList.EF;

namespace PackIt.Infrastructure.PackingList.Repositories;

internal sealed class PackingListDomainRepository : Repository<PackingListDbContext, Domain.Entities.PackingList>, 
    IPackingListDomainRepository
{
    public PackingListDomainRepository(PackingListDbContext context) : base(context)
    {
    }

    public async Task<Domain.Entities.PackingList> GetAsync(Guid id)
    {
        var list =
             await Context.PackingLists
            .Include(pl => pl.Items)
            .Include(pl => pl.Localization)
            .SingleOrDefaultAsync(pl => pl.Id == id);

        return list;
    }

    public async Task AddAsync(Domain.Entities.PackingList packingList)
    {
        await Context.PackingLists.AddAsync(packingList);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Domain.Entities.PackingList packingList)
    {
        Context.PackingLists.Update(packingList);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Domain.Entities.PackingList packingList)
    {
        Context.PackingLists.Remove(packingList);
        await Context.SaveChangesAsync();
    }
}
