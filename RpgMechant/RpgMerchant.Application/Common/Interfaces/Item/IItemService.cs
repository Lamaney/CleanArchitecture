using RpgMerchant.Application.Common.Interfaces.Item.Dto;

namespace RpgMerchant.Application.Common.Interfaces.Item;

public interface IItemService
{
    Task<ItemDto?> Create(CreateItemDto createItemDto);

    Task<ItemDto?> GetItemByIdAsync(long id);
}