using RpgMerchant.Application.Common.Interfaces.Item.Dto;

namespace RpgMerchant.Application.Common.Interfaces.Item;

public interface IItemService
{
    Task<CreateItemDto> Create(CreateItemDto createItemDto);
}