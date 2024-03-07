using FlightSystem.Models;

namespace FlightSystem.Views;

public partial class FindFlight : ContentPage
{
	public FindFlight()
	{
		InitializeComponent();
	}

	private void OnSubmitClicked(object sender, EventArgs e)
	{
		FlightRepository.SearchFlight(departureEntry.Text, arrivalEntry.Text, dayEntry.Text);
		
		Shell.Current.GoToAsync(nameof(DisplayFlight));
    }
}