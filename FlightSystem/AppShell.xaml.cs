using FlightSystem.Views;

namespace FlightSystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(FindFlight), typeof(FindFlight));
            Routing.RegisterRoute(nameof(DisplayFlight), typeof(DisplayFlight));
            Routing.RegisterRoute(nameof(Reserve), typeof(Reserve));
            Routing.RegisterRoute(nameof(AboutUs), typeof(AboutUs));
        }

    }
}
