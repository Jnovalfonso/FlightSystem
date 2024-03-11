using FlightSystem.Models;

namespace FlightSystem.Views;

public partial class FindFlight : ContentPage
{
	public FindFlight()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		arrivalEntry.Text = string.Empty;
		departureEntry.Text = string.Empty;
		dayEntry.Text = string.Empty;	
    }

    private void OnSubmitClicked(object sender, EventArgs e)
	{
		FlightRepository.SearchFlight(departureEntry.Text, arrivalEntry.Text, dayEntry.Text);
		
		Shell.Current.GoToAsync(nameof(DisplayFlight));
    }
}