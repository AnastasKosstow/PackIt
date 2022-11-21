using PackIt.Domain.ValueObjects;

namespace PackIt.Application.PackingList.Shared.DTOs;

public record PackingListDto(Guid Id, string Name, Localization Localization, IEnumerable<PackingItem> Items);
