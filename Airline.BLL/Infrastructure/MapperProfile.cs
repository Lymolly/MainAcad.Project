using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.Domain.Entities;
using AutoMapper;

namespace Airline.BLL.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FlightStatus, FlightStatusDTO>();
            CreateMap<WayDTO, Way>().ReverseMap();
            CreateMap<Plane, PlaneDTO>().ReverseMap();
            CreateMap<Info, InfoDTO>().ReverseMap();
            CreateMap<Passenger, PassengerDTO>().ReverseMap();
        }
        
    }

       
}
