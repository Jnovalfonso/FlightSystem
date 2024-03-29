﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystem.Models
{
    public static class FlightRepository
    {
        static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\", @"..\", @"..\", @"..\", @"..\", @"Resources\", @"Raw\", @"flights.txt");
        public static string FlightsTextFile = Path.GetFullPath(path);
 

        private static List<Flight> _flights;
        private static List<Flight> _foundFlights;
        private static int _count;
        public static List<Flight> Flights { get { return _flights; } set { _flights = value; } }
        public static List<Flight> FoundFlights { get { return _foundFlights; } set { _foundFlights = value; } }
        public static int Count { get { return _count; } set { _count = value; } }


        static FlightRepository()
        {
            if (_flights == null)
            {
                _flights = new List<Flight>();
                _foundFlights = new List<Flight>();
                FillFlightList();
            }
        }

        public static void SearchFlight (string departure, string arrival, string day)
        {
            FoundFlights.Clear();

            bool isDepartureEmpty = string.IsNullOrWhiteSpace(departure);
            bool isArrivalEmpty = string.IsNullOrWhiteSpace(arrival);
            bool isDayEmpty = string.IsNullOrWhiteSpace(day);
            
            if (isDepartureEmpty && isArrivalEmpty && isDayEmpty )
            {
                FoundFlights = Flights; // TODO
            }

            else
            {
                foreach (Flight flight in Flights)
                {
                    bool matchDeparture = isDepartureEmpty || flight.DepartureCity.ToLower() == departure.ToLower() || flight.DepartureCity.ToLower() == AirportRepository.GetAirportCode(departure).ToLower();
                    bool matchArrival = isArrivalEmpty || flight.ArrivalCity.ToLower() == arrival.ToLower() || flight.ArrivalCity.ToLower() == AirportRepository.GetAirportCode(arrival).ToLower();
                    bool matchDay = isDayEmpty || flight.Day.ToLower() == day.ToLower();

                    if (matchDeparture && matchArrival && matchDay)
                    {
                        _foundFlights.Add(flight);
                    }
                }
            }
            
            Count = _foundFlights.Count;
        }
        

        public static void FillFlightList()
        {
            try
            {
                string line;
                Flight flight = new Flight();

                using StreamReader reader = new StreamReader(FlightsTextFile);
                while ((line = reader.ReadLine()) != null)
                {
                    flight = CreateFlightInstance(line);
                    _flights.Add(flight);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        static Flight CreateFlightInstance(string line)
        {
            string[] parts = line.Split(',');

            string flightCode = parts[0];
            string airline = parts[1];
            string departureCity = parts[2];
            string arrivalCity = parts[3];
            string day = parts[4];
            string time = parts[5];
            int availableSeats = int.Parse(parts[6]);
            string cost = parts[7];

            Flight flight = new Flight(flightCode, airline, departureCity, arrivalCity, day, time, availableSeats, cost);

            return flight;
        }

    }
}

