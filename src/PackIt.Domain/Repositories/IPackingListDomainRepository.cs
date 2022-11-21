using PackIt.Domain.Abstractions;
using PackIt.Domain.Entities;

namespace PackIt.Domain.Repositories;

public interface IPackingListDomainRepository : IRepository<PackingList>
{
    Task<PackingList> GetAsync(Guid id);
    Task AddAsync(PackingList list);
    Task UpdateAsync(PackingList list);
    Task DeleteAsync(PackingList list);
}
