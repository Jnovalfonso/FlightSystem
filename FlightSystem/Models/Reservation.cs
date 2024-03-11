using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public bool IsActive { get; set; }
        public Flight ReservedFlight { get; set; }

        public Reservation(string name, string citizenship, bool isActive, Flight reservedFlight)
        {
            ReservationCode = ReservationManager.GetCode();
            Name = name;
            Citizenship = citizenship;
            IsActive = isActive;
            ReservedFlight = reservedFlight;
        }

        public Reservation(string reservationCode, string name, string citizenship, bool isActive, Flight reservedFlight)
        {
            ReservationCode = reservationCode;
            Name = name;
            Citizenship = citizenship;
            IsActive = isActive;
            ReservedFlight = reservedFlight;
        }
    }

}
