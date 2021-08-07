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
using Airline.Domain.IdentityEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airline.BLL.UoW
{
    public class IdentityUnitOfWork :IUnitOfWork
    {
        ApplicationContext db;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public IdentityUnitOfWork(string connStr)
        {
            db = new ApplicationContext(connStr);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get => userManager;
        }
        public ApplicationRoleManager RoleManager
        {
            get => roleManager;
        }
        public IClientManager ClientManager
        {
            get => clientManager;
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
