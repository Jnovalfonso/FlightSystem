using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public static class AirportRepository
    {
        private static Dictionary<string,string> _airportDictionary;
        private static int _count;
        public static Dictionary<string ,string> AirportDictionary { get {  return _airportDictionary; } set { _airportDictionary = value; } }
        public static int Count { get { return _count; } set { _count = value; } }

        static AirportRepository()
        {
            if (_airportDictionary == null)
            {
                _airportDictionary = new Dictionary<string, string>();
                 LoadAirportFile();
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


        static async void LoadAirportFile()
        {
            using Stream stream = await FileSystem.OpenAppPackageFileAsync("airports.txt");
            using StreamReader reader = new StreamReader(stream);

            string line;
            Airport airport = new Airport();


            try
            {
                while ((line = reader.ReadLine()) != null)
                {
                    airport = CreateAirportInstance(line);
                    _airportDictionary.Add(airport.AirportCode, airport.AirportName);
                }
            }   

            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
