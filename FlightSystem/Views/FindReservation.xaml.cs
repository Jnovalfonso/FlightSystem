using FlightSystem.Models;

namespace FlightSystem.Views;

public partial class FindReservation : ContentPage
{
	public FindReservation()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        codeEntry.Text = string.Empty;
        airlineEntry.Text = string.Empty;
        nameEntry.Text = string.Empty;
    }

    private void OnSubmitClicked(object sender, EventArgs e)
    {
        ReservationManager.SearchReservation(codeEntry.Text, airlineEntry.Text, nameEntry.Text);

        Shell.Current.GoToAsync(nameof(DisplayReservation));
    }
}