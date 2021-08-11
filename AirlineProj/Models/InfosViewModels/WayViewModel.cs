using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProj.Models.InfosViewModels
{
    public class WayViewModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Length { get; set; }
        public string Destination { get; set; }
    }
}