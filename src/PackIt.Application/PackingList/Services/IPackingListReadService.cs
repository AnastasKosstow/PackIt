namespace PackIt.Application.PackingList.Services;

public interface IPackingListReadService
{
    Task<bool> ExistsByNameAsync(string name);
}
