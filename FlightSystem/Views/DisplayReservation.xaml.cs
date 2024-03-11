using FlightSystem.Models;

namespace FlightSystem.Views;

public partial class DisplayReservation : ContentPage
{
	public DisplayReservation()
	{
		InitializeComponent();
		reservationCollection.ItemsSource = ReservationManager.foundReservations;

        if (ReservationManager.reservations.Count < 1)
        {
            DisplayAlert("No Reservations Created", $"There are not any existent reservations.", "OK");
        }

        else if (ReservationManager.foundReservations.Count < 1)
        {
            DisplayAlert("No Reservations Found", $"No flights were found with the arguments provided.", "OK");
        }
    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

}