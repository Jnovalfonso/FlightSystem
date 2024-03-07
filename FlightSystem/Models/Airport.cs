using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public class Airport
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }

        public Airport(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }
        public Airport()
        {
            
        }
    }
}
