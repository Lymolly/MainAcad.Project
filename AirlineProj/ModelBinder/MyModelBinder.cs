using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineProj.Models.InfosViewModels;


namespace AirlineProj.ModelBinder
{
    //Binded all without id
    public class MyModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException();
            var values = bindingContext.ValueProvider;
            
            string planemod = (string)values.GetValue("Plane.Model").ConvertTo(typeof(string));
            int capas = (int)values.GetValue("Plane.Capacity").ConvertTo(typeof(int));
            int wingsp = (int)values.GetValue("Plane.Wingspan").ConvertTo(typeof(int));
            string plNum = (string)values.GetValue("Plane.PlaneNumber").ConvertTo(typeof(string));
            decimal speed = (decimal)values.GetValue("Plane.Speed").ConvertTo(typeof(decimal));

            PlaneViewModel pvm = new PlaneViewModel
            {
                Model = planemod,
                Capacity = capas,
                Wingspan = wingsp,
                PlaneNumber = plNum,
                Speed = speed
            };

            string time = (string)values.GetValue("Route.Time").ConvertTo(typeof(string));
            string len = (string)values.GetValue("Route.Length").ConvertTo(typeof(string));
            string from = (string)values.GetValue("Route.From").ConvertTo(typeof(string));
            string to = (string)values.GetValue("Route.To").ConvertTo(typeof(string));
            WayViewModel route = new WayViewModel
            {
                Time = time,
                Length = len,
                From = from,
                To = to
            };
            string status = (string)values.GetValue("FlightStatus.Status").ConvertTo(typeof(string));
            FlightStatusViewModel flStat = new FlightStatusViewModel
            {
                Status = status
            };

            string arr = (string)values.GetValue("ArrivalTime").ConvertTo(typeof(string));
            int term = (int)values.GetValue("Terminal").ConvertTo(typeof(int));
            int gate = (int)values.GetValue("Gate").ConvertTo(typeof(int));
            decimal price = (decimal)values.GetValue("Price").ConvertTo(typeof(decimal));
            int flNum = (int)values.GetValue("FlightNumber").ConvertTo(typeof(int));
            string dep = (string)values.GetValue("DepartureTime").ConvertTo(typeof(string));

            CreateInfoViewModel ivm = new CreateInfoViewModel
            {
                Plane = pvm,
                ArrivalTime = arr,
                DepartureTime = dep,
                FlightNumber = flNum,
                Route = route,
                FlightStatus = flStat,
                Terminal = term,
                Gate = gate,
                Price = price
            };
            return ivm;
        }
    }
}