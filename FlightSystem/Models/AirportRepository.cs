using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public static class AirportRepository
    {
        public const string AirportsTextFile = "C:\\Users\\asus\\OneDrive\\Documents\\SAIT\\6. Object-Oriented Programming II\\C#\\Assignments\\FlightSystem\\FlightSystem\\Resources\\Raw\\airports.txt";
        //static string Path = Path.Combine(Environment.CurrentDirectory, @"Raw\", AirportsTextFile);

        private static Dictionary<string,string> _airportDictionary;
        private static int _count;
        public static Dictionary<string ,string> AirportDictionary { get {  return _airportDictionary; } set { _airportDictionary = value; } }
        public static int Count { get { return _count; } set { _count = value; } }

        static AirportRepository()
        {
            if (_airportDictionary == null)
            {
                _airportDictionary = new Dictionary<string, string>();
                FillAirportDictionary();
                _count = _airportDictionary.Count;
            }
        }

        public static string GetAirportCode(string airportName)
        {
            foreach (var kvp in _airportDictionary)
            {
                if (kvp.Value == airportName)
                {
                    return kvp.Key; 
                }
            }

            return airportName;
        }

        public static void FillAirportDictionary()
        {
            try
            {
                string line;
                Airport airport = new Airport();

                using StreamReader reader = new StreamReader(AirportsTextFile);
                while ((line = reader.ReadLine()) != null)
                {
                    airport = CreateAirportInstance(line);
                    _airportDictionary.Add(airport.AirportCode, airport.AirportName);
                }
            }

            catch (Exception ex)
            {
                _count = -1;
            }
        }

        public static Airport CreateAirportInstance(string line)
        {
            string[] parts = line.Split(',');

            string airportCode = parts[0];
            string airportName = parts[1];

            Airport airport = new Airport(airportCode, airportName);

            return airport;
        }
    }
}
