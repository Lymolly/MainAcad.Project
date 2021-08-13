using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Plane : BaseEntity
    {
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Wingspan { get; set; }
        public decimal Speed { get; set; }
        public string PlaneNumber { get; set; }
        public Way Way { get; set; }
    }
}
