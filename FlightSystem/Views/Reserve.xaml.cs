using FlightSystem.Models;
using FlightSystem.Exceptions;

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

    private void OnSumbitClicked(object sender, EventArgs e)
    {

        try
        {
            GetSeats();
            ValidateNotEmpty(name.Text, "Name");
            ValidateNotEmpty(citizenship.Text, "Citizenship");
            ValidateNotEmpty(status.SelectedItem as string, "Status");

            Reservation reservation = ReservationManager.CreateReservationInstance(name.Text, citizenship.Text, status.SelectedItem as string, SelectedFlight);

            DisplayAlert("Reserved Successfully", $"The reservation: {reservation.ReservationCode} has been saved.", "OK");
            Shell.Current.GoToAsync("..\\..");

        }

        catch (EmptyReservationField ex)
        {
            DisplayAlert("Validation Error", ex.ExceptionMessage, "OK");
        }

        catch (CompletelyBooked ex)
        {
            DisplayAlert("Flight Availability Error", ex.ExceptionMessage, "OK");
            Shell.Current.GoToAsync("..\\..");
        }

        void ValidateNotEmpty(string fieldValue, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldValue))
            {
                throw new EmptyReservationField(fieldName);
            }
        }

        void GetSeats()
        {
            if (SelectedFlight.AvailableSeats <= 1)
            {
                throw new CompletelyBooked();
            }
        }
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..\\..");
    }


}