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

    public async Task<CreateItemDto> Create(CreateItemDto createItemDto)
    {
        try
        {
            await _repository.AddAsync(_mapper.Map<Domain.Models.Item>(createItemDto));
            await _unitOfWork.CommitAsync();
            return new CreateItemDto();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}