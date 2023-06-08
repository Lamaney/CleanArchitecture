using AutoMapper;
using RpgMerchant.Application.Common.Interfaces.Item;
using RpgMerchant.Application.Common.Interfaces.Item.Dto;
using RpgMerchant.Domain.Common.Interfaces;
using RpgMerchant.Domain.Repositories.Interfaces;

namespace RpgMerchant.Application.Services.Item;

public class ItemService:IItemService
{
    private readonly IItemRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
      
    }

    public async Task<ItemDto?> Create(CreateItemDto createItemDto)
    {
        try
        {
            var entity=await _repository.InsertAsync(_mapper.Map<Domain.Models.Item>(createItemDto));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ItemDto>(entity);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public async Task<ItemDto?> GetItemByIdAsync(long id)
    {
        try
        {
            var entity = _mapper.Map<ItemDto>(await _repository.GetByIdAsync(id));
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}