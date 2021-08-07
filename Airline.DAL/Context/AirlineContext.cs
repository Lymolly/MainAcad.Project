using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.DAL.Context
{
    public class AirlineContext : DbContext
    {
        public AirlineContext() : base("AirlineDB")
        { }
    }
}
