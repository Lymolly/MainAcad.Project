using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL.Repoitories
{
    public class InfoRepository : IRepository<Info>
    {
        public IQueryable<Info> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Info> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Info entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Info entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Info entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }
    }
}
