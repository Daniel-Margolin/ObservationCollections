using ObservationCollections.ViewModels;
using ObservationCollections.Models;


namespace ObservationCollections.Views;

public partial class MuscleList : ContentPage
{
    #region Constructor

    public MuscleList(User user)
    {
        MuscleListViewModel vm = new MuscleListViewModel(user);

        InitializeComponent();

        BindingContext = vm;
    }

    #endregion
}