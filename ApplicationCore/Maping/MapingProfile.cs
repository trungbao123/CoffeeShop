using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<SaveMenuDto, Menu>();
            CreateMap<MenuDto, SaveMenuDto>();

            CreateMap<User, UserDto>();
            CreateMap<SaveUserDto, User>();
            CreateMap<UserDto, SaveUserDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<SaveOrderDto, Order>();
            CreateMap<OrderDto, SaveOrderDto>();

            CreateMap<Material, MaterialDto>();
            CreateMap<SaveMaterialDto, Material>();
            CreateMap<MaterialDto, SaveMaterialDto>();

            CreateMap<DetailOrder, DetailOrderDto>();
            CreateMap<SaveDetailOrderDto, DetailOrder>();
            CreateMap<DetailOrderDto, SaveDetailOrderDto>();
        }
    }
}