using System;
using System.Linq;
using System.Threading.Tasks;
using Airline.Domain.Entities;

namespace Airline.DAL.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        Task DeleteById(int id);
        void Delete(T entity);
        Task<int> Save();

    }
}