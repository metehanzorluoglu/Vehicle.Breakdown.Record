using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;
using VehicleBreakdownRecord.Entity.Entities;

namespace VehicleBreakdownRecor.Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Vehicle,VehicleDto>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDto>().ReverseMap();
            CreateMap<VehicleComment,VehicleCommentDto>().ReverseMap();
            CreateMap<BreakdownListDto,BreakdownListUpdateDto>().ReverseMap();

            CreateMap<UserAppDto,UserApp>().ReverseMap();

            CreateMap<Vehicle,BreakdownListDto>().ReverseMap();
            CreateMap<VehicleBreakdownList, BreakdownList>().ReverseMap();

            CreateMap<BreakdownList, BreakdownListDto>().ReverseMap();


            CreateMap<Vehicle, VehicleWithBreakdownAndCommentDto>()
                .ForMember(dest => dest.BreakdownList,
                opt => opt.MapFrom(src => src.VehicleBreakdownLists.Select(x=>x.BreakdownList).ToList()));
            CreateMap<VehicleBreakdownList, BreakdownListDto>();

            CreateMap<VehicleWithBreakdownAndCommentDto, Vehicle>();
            CreateMap<Vehicle,VehicleWithCommentDto>().ReverseMap();
            
            
        }
    }
}
