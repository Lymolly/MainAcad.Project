using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Airline.BLL.DTOs;
using AutoMapper;

namespace AirlineProj.Configuration
{
    public class MapperConfig
    {
        public Mapper Map<T>()
        {
            var cfg = new MapperConfiguration(c => c.CreateMap<T, UserDTO>());
            return new Mapper(cfg);
        }
    }
}