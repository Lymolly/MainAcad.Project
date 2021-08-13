using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProj.Models.InfosViewModels
{
    public class PassengerViewModel
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public InfoViewModel FlightInfo { get; set; }
    }
}