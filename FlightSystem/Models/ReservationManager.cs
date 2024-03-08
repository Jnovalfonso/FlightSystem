using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    static class ReservationManager
    {
        static List<string> existingCodes = new List<string>();
        public static List<Reservation> reservations = new List<Reservation>();
        public static string GetCode()
        {
            string code = string.Empty;

            while (code.Length != 5)
            {
                if (code.Length < 2) 
                {
                    code += GetLetter();
                }
                else
                {
                    code += GetNumber();
                }
            }

            if (!(existingCodes.Contains(code)))
            {
                existingCodes.Add(code);
                return code;
            }

            else
            {
                return GetCode();
            }

            char GetLetter()
            {
                Random random = new Random();
                const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                int index = random.Next(letters.Length);

                return letters[index];
            }

            int GetNumber()
            {
                Random random = new Random();
                int num = random.Next(10);

                return num;
            }
        }

        public static void CreateReservationInstance (string name, string citizenship, bool isActive, Flight reservedFlight)
        {
            Reservation reservation = new Reservation(name, citizenship, isActive, reservedFlight);
            reservations.Add(reservation);
        }
    }
}
