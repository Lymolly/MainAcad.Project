﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.DTOs
{
    public class WayDTO
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Length { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
