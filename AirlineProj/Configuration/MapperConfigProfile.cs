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
            CreateMap<WayViewModel, WayDTO>().ReverseMap()
                .ForMember("Destination",opt =>opt.MapFrom(m =>m.From + "--" +m.To));
            CreateMap<RegisterViewModel, UserDTO>();
        }
    }
}