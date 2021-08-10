using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.Identity;
using Airline.BLL.Repoitories;
using Airline.DAL.Context;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL
{
    public class UnitOfWork
    {
        private PlaneRepository planeRepo;
        public UnitOfWork(IRepository<BaseEntity> repository)
        {
            planeRepo = (PlaneRepository)repository;
        }

        public PlaneRepository PlaneRepository
        {
            get => planeRepo;
        }
       
        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
