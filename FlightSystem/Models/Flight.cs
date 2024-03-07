using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int AvailableSeats { get; set; }
        public string Cost { get; set; }

        public Flight(string flightCode, string airline, string departureCity, string arrivalCity, string day, string time, int availableSeats, string cost)
        {
            FlightCode = flightCode;
            Airline = airline;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            Day = day;
            Time = time;
            AvailableSeats = availableSeats;
            Cost = cost;
        }
        public Flight()
        {
            
        }
    }
}
