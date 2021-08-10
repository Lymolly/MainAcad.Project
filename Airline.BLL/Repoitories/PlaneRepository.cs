using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Context;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL.Repoitories
{
    public class PlaneRepository : IRepository<Plane>
    {
        public AirlineContext Database { get;}

        public PlaneRepository(AirlineContext context)
        {
            Database = context;
        }
        public IQueryable<Plane> GetAll()
        {
            return Database.Planes
                .Include(p => p.Passengers)
                .Include(p => p.Way)
                .AsNoTracking().AsQueryable();
        }

        public async Task<Plane> GetById(int id)
        {
            return await Database.Planes
                .Include(p => p.Passengers)
                .Include(p => p.Way)
                .AsNoTracking().FirstAsync(p => p.Id == id);
        }

        public void Add(Plane entity)
        { 
            Database.Planes.Add(entity);
        }

        public void Update(Plane entity)
        {
            Database.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteById(int id)
        {
            Plane planeToDelete = await Database.Planes.FindAsync(id);
            if (planeToDelete != null)
            {
                Database.Planes.Remove(planeToDelete);
            }
        }

        public void Delete(Plane entity)
        {
            
            Database.Planes.Remove(entity);
        }

        public async Task<int> Save()
        {
            return await Database.SaveChangesAsync();
        }
    }
}
