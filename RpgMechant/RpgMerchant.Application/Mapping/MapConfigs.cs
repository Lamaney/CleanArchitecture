﻿using AutoMapper;
using RpgMerchant.Application.Common.Interfaces.Item.Dto;
using RpgMerchant.Domain.Models;

namespace RpgMerchant.Application.Mapping;

public class MapConfigs:Profile
{
    public MapConfigs()
    {
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Item, CreateItemDto>().ReverseMap();
    }
}