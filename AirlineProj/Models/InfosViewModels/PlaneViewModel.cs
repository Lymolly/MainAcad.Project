﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineProj.Models.InfosViewModels
{
    public class PlaneViewModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Wingspan { get; set; }
        public decimal Speed { get; set; }
        public string PlaneNumber { get; set; }
        public WayViewModel Way { get; set; }
    }
}