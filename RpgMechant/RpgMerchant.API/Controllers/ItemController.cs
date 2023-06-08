using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RpgMerchant.Application.Common.Interfaces.Item;
using RpgMerchant.Application.Common.Interfaces.Item.Dto;

namespace RpgMerchant.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController:ControllerBase
{

    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("getItemById/{id}")]
    public async Task<IActionResult> GetItemById(long id)
    {
        var data = await _itemService.GetItemByIdAsync(id);

        if (data is null)
        {
            return NotFound();
        }
        
        return Ok(data);
    }

    [HttpPost("CreateItem")]
    public async Task<IActionResult> CreateItem(CreateItemDto data)
    {
        var entity=await _itemService.Create(data);

        if (entity is null)
        {
            return BadRequest();
        }

        return Ok(entity);
    }
    
}