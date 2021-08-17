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
        private InfoRepository infoRepo;
        private PassengerRepository passengerRepo;
        private AirlineContext db;
        public UnitOfWork()
        {
            db = new AirlineContext();
        }

        public PlaneRepository PlaneRepository
        {
            get => planeRepo ?? (planeRepo = new PlaneRepository(db));
        }
        public InfoRepository InfoRepository
        {
            get => infoRepo ?? (infoRepo = new InfoRepository(db)); 
        }
        public PassengerRepository PassengerRepository
        {
            get => passengerRepo ?? (passengerRepo = new PassengerRepository(db));
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
