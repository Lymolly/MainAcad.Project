using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airline.DAL.Context
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(string connectionstring) : base(connectionstring) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
