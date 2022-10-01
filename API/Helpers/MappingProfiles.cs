using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(d=>d.ProductId, o=>o.MapFrom(s=>s.Product.Id))
                .ForMember(d=>d.ProductName, o=>o.MapFrom(s=>s.Product.Name))
                .ForMember(d=>d.UnitPrice, o=>o.MapFrom(s=>s.Product.UnitPrice));

            CreateMap<Address, AddressDto>().ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(d => d.OrderId, o => o.MapFrom(s => s.Id));
        }
    }
}
