using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.DTOs
{
    public class PlaneDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Wingspan { get; set; }
        public decimal Speed { get; set; }
        public string PlaneNumber { get; set; }
        public ICollection<PassengerDTO> Passengers { get; set; }
        public WayDTO Way { get; set; }
    }
}
