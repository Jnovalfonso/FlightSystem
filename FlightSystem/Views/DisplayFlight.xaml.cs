using FlightSystem.Models;
using System.Collections.ObjectModel;
using System.Formats.Tar;

namespace FlightSystem.Views;

public partial class DisplayFlight : ContentPage
{
	public DisplayFlight()
	{
		InitializeComponent();
        flightCollection.ItemsSource = FlightRepository.FoundFlights;
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void OnItemSelected (object sender, SelectionChangedEventArgs e)
    {
        if (flightCollection.SelectedItem != null)
        {
            Flight flight = e.CurrentSelection.FirstOrDefault() as Flight;

            var navigationParameter = new ShellNavigationQueryParameters { { "flight", flight } };
            Shell.Current.GoToAsync(nameof(Reserve), navigationParameter);
        }
    }
}