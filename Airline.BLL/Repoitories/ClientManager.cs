using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DAL.Context;
using Airline.DAL.Interfaces;
using Airline.Domain.Entities;

namespace Airline.BLL.Repoitories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext context)
        {
            Database = context;
        }
        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
        public void Dispose()
        {
        }

    }
}
