namespace FlightApp.Views;

public partial class AboutUsPage : ContentPage
{
	public AboutUsPage()
	{
		InitializeComponent();
	}

    private void Reuturn_back_from_about_us_page_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}
