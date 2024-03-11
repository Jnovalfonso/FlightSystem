using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSystem.Exceptions;

namespace FlightSystem.Models
{
    static class ReservationManager
    {
        const string ReservationsTextFile = "C:\\Users\\asus\\OneDrive\\Documents\\SAIT\\6. Object-Oriented Programming II\\C#\\Assignments\\FlightSystem\\FlightSystem\\Resources\\Raw\\reservations.txt";
        static List<string> existingCodes = new List<string>();
        public static List<Reservation> reservations = new List<Reservation>();
        public static List<Reservation> foundReservations = new List<Reservation>();

        static ReservationManager()
        {
            if (reservations.Count == 0)
            {
                FillReservationList();
            }
        }

        public static void FillReservationList() 
        {
            string[] lines = File.ReadAllLines(ReservationsTextFile);
            try
            {
                foreach (string line in lines)
                {
                    Reservation reservation = CreateReservationInstanceFromFile(line);
                    reservations.Add(reservation);
                    existingCodes.Add(reservation.ReservationCode);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            Reservation CreateReservationInstanceFromFile(string line)
            {
                string[] parts = line.Split(',');

                string reservationCode = parts[0];
                string name = parts[1];
                string citizenship = parts[2];
                bool isActive = bool.Parse(parts[3]);
                Flight flight = FlightRepository.Flights.FirstOrDefault(flight => flight.FlightCode == parts[4]);

                Reservation reservation = new Reservation(reservationCode, name, citizenship, isActive, flight);

                Debug.WriteLine($"{reservationCode},{name},{citizenship},{isActive},{flight.FlightCode}");
                return reservation;
            }
        }

        public static void SearchReservation (string reservationCode, string airline, string name)
        {
            foundReservations.Clear();

            bool isCodeEmpty = string.IsNullOrWhiteSpace(reservationCode);
            bool isAirlineEmpty = string.IsNullOrWhiteSpace(airline);
            bool isNameEmpty = string.IsNullOrWhiteSpace(name);


            foreach (Reservation reservation in reservations) 
            { 
                bool matchCode = isCodeEmpty || reservation.ReservationCode.ToLower() == reservationCode.ToLower();
                bool matchAirline = isAirlineEmpty || reservation.ReservedFlight.Airline.ToLower() ==airline.ToLower();
                bool matchName = isNameEmpty || reservation.Name.ToLower() == name.ToLower();

                if (matchCode && matchAirline && matchName)
                {
                    foundReservations.Add(reservation);
                }
            }
        }
        public static string GetCode()
        {
            string code = string.Empty;

            while (code.Length != 5)
            {
                if (code.Length < 1) 
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

        public static Reservation CreateReservationInstance (string name, string citizenship,  string isActive, Flight reservedFlight)
        {
           
            Reservation reservation = new Reservation(name, citizenship, GetStatus(isActive), reservedFlight);
            reservations.Add(reservation);

            SaveToFile(reservation.ReservationCode, reservation.Name, reservation.Citizenship, reservation.IsActive, reservation.ReservedFlight.FlightCode);

            UpdateFlightsFile();

            return reservation;

            bool GetStatus(string statusSelected)
            {
                switch (statusSelected)
                {
                    case "Active":
                        return true;
                    case "Inactive":
                        return false;
                    default:
                        return false;

                }
            }

            void SaveToFile(string reservationCode, string name, string citizenship, bool isActive, string flightCode) 
            {
                using (StreamWriter writer = new StreamWriter(ReservationsTextFile, true))
                {
                    writer.WriteLine($"{reservationCode},{name},{citizenship},{isActive},{flightCode}");
                }
            }

            void UpdateFlightsFile ()
            {
                reservedFlight.AvailableSeats -= 1;

                int lineToUpdate = FlightRepository.Flights.IndexOf(reservedFlight);

                string[] lines = File.ReadAllLines(FlightRepository.FlightsTextFile);

                // Check if the line to update is within the valid range
                if (lineToUpdate >= 0 && lineToUpdate < lines.Length)
                {
                    // Update the specified line
                    lines[lineToUpdate] = $"{reservedFlight.FlightCode},{reservedFlight.Airline},{reservedFlight.DepartureCity},{reservedFlight.ArrivalCity},{reservedFlight.Day},{reservedFlight.Time},{reservedFlight.AvailableSeats},{reservedFlight.Cost}";

                    // Write the updated content back to the file
                    File.WriteAllLines(FlightRepository.FlightsTextFile, lines);

                    Debug.WriteLine($"Line {lineToUpdate + 1} has been updated.");
                }

            }
        }
    }
}
