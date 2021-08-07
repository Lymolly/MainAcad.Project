using System;
using System.Threading.Tasks;
using Airline.BLL.Identity;
using Airline.DAL.Interfaces;

namespace Airline.BLL
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}