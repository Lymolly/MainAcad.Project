using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Info : BaseEntity
    {
        public Plane Plane { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int FlightNumber { get; set; }
        public Way Route { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public int Terminal { get; set; }
        public int Gate { get; set; }
        public decimal Price { get; set; }
        public ICollection<Passenger> Passengers { get; set; }
    }
}
