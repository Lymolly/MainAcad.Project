using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.DTOs;
using Airline.BLL.Infrastructure;
using Airline.Domain.Entities;
using AutoMapper;

namespace Airline.BLL.Services
{
    public class InfoService
    {
        private UnitOfWork uow;
        static MapperConfiguration config =
            new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));

        public InfoService()
        {
            uow = new UnitOfWork();
        }
        public IEnumerable<InfoDTO> GetAll()
        {
            var res = uow.InfoRepository.GetAll().AsEnumerable();
            var mapper = new Mapper(config);

            var infos = mapper.Map<IEnumerable<InfoDTO>>(res);
            return infos;
        }

        public async Task AddNewInfo(InfoDTO info)
        {
            var mapper = new Mapper(config);
            var data = mapper.Map<Info>(info);
            uow.InfoRepository.Add(data);
            await uow.SaveAsync();
        }
    }
}
