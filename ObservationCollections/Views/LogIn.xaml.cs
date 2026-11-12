using ObservationCollections.ViewModels;

namespace ObservationCollections.Views;

public partial class LogIn : ContentPage
{
    #region Constructor

    public LogIn()
    {
        LogInViewModel vm = new LogInViewModel();
        InitializeComponent();
        BindingContext = vm;
    }

    #endregion
}