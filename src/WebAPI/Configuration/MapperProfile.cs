using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            CreateMap<Order, OrderDto>()
                .ForMember(src => src.Details, opt => opt.MapFrom(dest => dest.Details))
                .AfterMap((dest,src) =>
                {
                    foreach (var detail in dest.Details)
                    {
                        //CreateMap<OrderDET, OrderDETDto>();
                        //src.Details.Add((OrderDET)detail);
                    }
                });
        }
    }
}
