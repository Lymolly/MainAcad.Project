using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.BLL.Repoitories;
using Airline.Domain.Entities;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class PlaneService
    {
        private UnitOfWork uow;
        static MapperConfiguration config =
            new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
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

            var mapper = new Mapper(config);

            var planes = mapper.Map<IEnumerable<PlaneDTO>>(res);
            var planesDto = planes;
            return planesDto;
        }
        public async Task UpdatePlane(PlaneDTO info)
        {
            var mapper = new Mapper(config);
            var data = mapper.Map<Plane>(info);
            uow.PlaneRepository.Update(data);
            await uow.SaveAsync();
        }
    }
}
