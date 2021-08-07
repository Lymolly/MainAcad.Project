using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.BLL.Identity;
using Airline.DAL.Interfaces;

namespace Airline.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ApplicationUserManager UserManager { get; }
        public IClientManager ClientManager { get; }
        public ApplicationRoleManager RoleManager { get; }
        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
