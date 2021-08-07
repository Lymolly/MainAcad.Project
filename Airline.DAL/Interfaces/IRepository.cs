using System.Linq;
using System.Threading.Tasks;
using Airline.Domain.Entities;

namespace Airline.DAL.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task DeleteById(int id);
        Task Delete(T entity);
        Task<int> Save();

    }
}