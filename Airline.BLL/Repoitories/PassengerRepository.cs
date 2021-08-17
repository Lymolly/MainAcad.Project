using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Context;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL.Repoitories
{
    public class PassengerRepository : IRepository<Passenger>
    {
        private AirlineContext Database { get; }

        public PassengerRepository(AirlineContext context)
        {
            Database = context;
        }
        public IQueryable<Passenger> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Passenger entity)
        {
            Database.Passengers.Add(entity);
        }

        public void Update(Passenger entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Passenger entity)
        {
            throw new NotImplementedException();
        }
    }
}
