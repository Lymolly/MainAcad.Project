using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Domain.Entities
{
    public class Way : BaseEntity
    {
        public string Time { get; set; }
        public string Length { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
