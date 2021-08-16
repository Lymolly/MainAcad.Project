using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Airline.BLL.DTOs;
using AirlineProj.Models;
using AirlineProj.Models.InfosViewModels;
using AutoMapper;

namespace AirlineProj.Configuration
{
    public class MapperConfigProfile : Profile
    {
        public MapperConfigProfile()
        {
            CreateMap<InfoDTO, InfoViewModel>().ReverseMap();
            CreateMap<PlaneDTO, PlaneViewModel>().ReverseMap();
            CreateMap<PassengerDTO, PassengerViewModel>().ReverseMap();
            CreateMap<FlightStatusDTO, FlightStatusViewModel>().ReverseMap();
            CreateMap<WayDTO,WayViewModel > ().ForMember(m => m.Destination,opt =>opt.Ignore()).ReverseMap();
            CreateMap<RegisterViewModel, UserDTO>();
        }
    }
}