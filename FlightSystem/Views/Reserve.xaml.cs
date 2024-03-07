using FlightSystem.Models;

namespace FlightSystem.Views;

[QueryProperty(nameof(SelectedFlight), "flight")]
public partial class Reserve : ContentPage
{
    Flight _selectedFlight;
	public Reserve()
	{
		InitializeComponent();
	}

    public Flight SelectedFlight
    {
        set
        {
            _selectedFlight = value;

            if (_selectedFlight != null)
            {
                flightCode.Text = _selectedFlight.FlightCode;
                airline.Text = _selectedFlight.Airline;
                departure.Text = _selectedFlight.DepartureCity;
                arrival.Text = _selectedFlight.ArrivalCity;
                day.Text = _selectedFlight.Day;
                time.Text = _selectedFlight.Time;
                seats.Text = _selectedFlight.AvailableSeats.ToString();
                cost.Text = _selectedFlight.Cost;
            }
        }

        get
        {
            return _selectedFlight;
        }
    }
}