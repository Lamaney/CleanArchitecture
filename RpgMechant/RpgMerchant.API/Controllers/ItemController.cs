using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RpgMerchant.Application.Common.Interfaces.Item;
using RpgMerchant.Application.Common.Interfaces.Item.Dto;

namespace RpgMerchant.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ItemController:ControllerBase
{

    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public IActionResult Deneme()
    {
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemDto data)
    {
        await _itemService.Create(data);

        return Ok();
    }
    
}