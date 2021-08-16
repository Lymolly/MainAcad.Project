using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirlineProj.Models.InfosViewModels
{
    public class WayViewModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Length { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        [NotMapped]
        public string Destination
        {
            get => From + " --- " + To; 
        }
    }
}