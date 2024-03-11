using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Exceptions
{
    [Serializable]
    public class EmptyReservationField : Exception
    {
        public string ExceptionMessage {  get; set; }
        public EmptyReservationField(string emptyField) 
        {
            ExceptionMessage = $"The field: '{emptyField}' can't be empty.";
        }
    }

    [Serializable]
    public class CompletelyBooked : Exception
    {
        public string ExceptionMessage { get; set; }
        public CompletelyBooked()
        {
            ExceptionMessage = "Flight is completely booked.";
        }
    }

}
