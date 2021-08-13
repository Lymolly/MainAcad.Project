using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Domain.Entities;

namespace Airline.BLL.DTOs
{
    public class InfoDTO
    {
        public int Id { get; set; }
        public PlaneDTO Plane { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int FlightNumber { get; set; }
        public WayDTO Route { get; set; }
        public FlightStatusDTO FlightStatus { get; set; }
        public int Terminal { get; set; }
        public int Gate { get; set; }
        public decimal Price { get; set; }
        public ICollection<PassengerDTO> Passengers { get; set; }
    }
}
