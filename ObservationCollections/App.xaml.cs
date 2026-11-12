using ObservationCollections.Services;
using ObservationCollections.Views;

namespace ObservationCollections
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DataRepository.FillFakeData();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new LogIn()));
        }
    }
}