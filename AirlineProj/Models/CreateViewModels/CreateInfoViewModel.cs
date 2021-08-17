using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineProj.ModelBinder;
using AirlineProj.Models.CreateViewModels;

namespace AirlineProj.Models.InfosViewModels
{
    [ModelBinder(typeof(MyModelBinder))]
    public class CreateInfoViewModel
    {
        //public int Id { get; set; }
        public PlaneViewModel Plane { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
        public int FlightNumber { get; set; }
        public WayViewModel Route { get; set; }
        public FlightStatusViewModel FlightStatus { get; set; }
        public int Terminal { get; set; }
        public int Gate { get; set; }
        public decimal Price { get; set; }
        public ICollection<CreatePassengerViewModel> Passengers { get; set; }
    }
}