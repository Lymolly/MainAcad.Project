using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.BLL.Interfaces;
using Airline.BLL.Repoitories;
using Airline.Domain.Entities;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class PlaneService
    {
        private UnitOfWork uow;
        public PlaneService()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<PlaneDTO> GetAll()
        {
            var res = uow.PlaneRepository.GetAll().AsEnumerable();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Passenger, PassengerDTO>();
                cfg.CreateMap<Way, WayDTO>();
                cfg.CreateMap<Plane, PlaneDTO>();
            });

                //.ForMember("Passengers",opt =>opt.MapFrom(src => src.Passengers))
                //.ForMember("Way",opt => opt.MapFrom(src => src.Way)));
            var mapper = new Mapper(config);

            var planes = mapper.Map<IEnumerable<PlaneDTO>>(res);
            var planesDto = planes;
            return planesDto;
        }
    }
}
