using Xamarin.Forms;

namespace FlightSystem.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AboutUsButton_Clicked(object sender, EventArgs e)
        {
            // Redirect to the About Us tab/page
            Navigation.PushAsync(new AboutUsPage());
        }

        private void FindFlightsButton_Clicked(object sender, EventArgs e)
        {
            // Redirect to the Find Flights tab/page
            Navigation.PushAsync(new FindFlightsPage());
        }
    }
}
