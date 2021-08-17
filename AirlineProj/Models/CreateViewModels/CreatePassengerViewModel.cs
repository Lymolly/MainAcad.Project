using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineProj.ModelBinder;
using AirlineProj.Models.InfosViewModels;

namespace AirlineProj.Models.CreateViewModels
{
    [ModelBinder(typeof(MyModelBinder))]
    public class CreatePassengerViewModel
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public CreateInfoViewModel FlightInfo { get; set; }
    }
}