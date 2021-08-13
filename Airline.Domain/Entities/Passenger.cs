using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Passenger : BaseEntity
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Info FlightInfo { get; set; }
    }
}
