using System.Data.Entity;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Context;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL.Repoitories
{
    public class InfoRepository : IRepository<Info>
    {
        private AirlineContext Database { get; }

        public InfoRepository(AirlineContext context)
        {
            Database = context;
        }
        public IQueryable<Info> GetAll()
        {
             var ent = Database.Infos
                 .Include(i => i.Plane)
                 .Include(i => i.Route)
                 .Include(i => i.Passengers)
                 .Include(i => i.FlightStatus).AsNoTracking().AsQueryable();
            return ent;
        }

        public async Task<Info> GetById(int id)
        {
            return await Database.Infos
                .Include(i => i.Plane)
                .Include(i => i.Route)
                .Include(i => i.Passengers)
                .Include(i => i.FlightStatus).FirstOrDefaultAsync(i => i.Id == id);
        }

        public void Add(Info entity)
        {
            Database.Infos.Add(entity);
        }

        public void Update(Info entity)
        {
            Database.Entry(entity).State = EntityState.Modified;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Info entity)
        {
            throw new NotImplementedException();
        }

        //public Task<int> Save()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
