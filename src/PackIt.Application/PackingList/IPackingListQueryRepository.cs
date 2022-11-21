using PackIt.Application.PackingList.Shared.DTOs;

namespace PackIt.Application.PackingList;

public interface IPackingListQueryRepository
{
    Task<IEnumerable<PackingListDto>> SearchAsync(string name);
    Task<PackingListDto> TryGetByIdAsync(Guid id);
    Task<bool> ExistsByNameAsync(string name);
}
