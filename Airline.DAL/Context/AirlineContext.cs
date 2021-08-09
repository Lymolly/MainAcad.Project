using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Domain.Entities;

namespace Airline.DAL.Context
{
    public class AirlineContext : DbContext
    {
        public AirlineContext() : base("AirlineDB")
        { }

        public DbSet<Info> Infos { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
