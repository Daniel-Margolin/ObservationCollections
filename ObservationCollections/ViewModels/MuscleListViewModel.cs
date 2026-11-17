using System.Collections.ObjectModel;
using ObservationCollections.Models;
using ObservationCollections.Services;

namespace ObservationCollections.ViewModels
{
    public class MuscleListViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<Muscle> muscles =
            new ObservableCollection<Muscle>();

        private Muscle? selectedMuscle;

        private User currentUser;

        #endregion  

        #region Properties

        public ObservableCollection<Muscle> Muscles
        {
            get { return muscles; }
            set
            {
                muscles = value;
                OnPropertyChanged();
            }
        }

        public List<string> BodyParts { get; set; } =
            new List<string>
            {
                "Arms",
                "Chest",
                "Back",
                "Legs",
                "Shoulders",
                "Abs"
            };

        public Muscle? SelectedMuscle
        {
            get { return selectedMuscle; }
            set
            {
                if (selectedMuscle != value)
                {
                    selectedMuscle = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Commands

        public Command AddMuscleCommand { get; }
        public Command DeleteMuscleCommand { get; }
        public Command ClearSelectionCommand { get; }

        #endregion
        
        #region Constructor

        public MuscleListViewModel(User user)
        {
            currentUser = user;

            // Copy the user's List into an ObservableCollection.

            Muscles = new ObservableCollection<Muscle>(currentUser.Muscles);

            AddMuscleCommand = new Command(AddMuscle);
            DeleteMuscleCommand = new Command(DeleteMuscle);
            ClearSelectionCommand = new Command(ClearSelection);
        }

        #endregion

        #region Methods

        private void AddMuscle()
        {
            Muscle newMuscle = new Muscle
            {
                Name = "New Muscle",
                BodyPart = "Arms"
            };

            // Add the muscle to the DataRepository.

            DataRepository.AddMuscle(currentUser, newMuscle);

            // Add the muscle to the ObservableCollection.

            Muscles.Add(newMuscle);

            SelectedMuscle = newMuscle;
        }

        private void DeleteMuscle()
        {
            if (SelectedMuscle == null)
            {
                return;
            }

            // Remove the muscle from the DataRepository.

            DataRepository.RemoveMuscle(currentUser, SelectedMuscle);

            // Remove the muscle from the ObservableCollection.

            Muscles.Remove(SelectedMuscle);

            SelectedMuscle = null;
        }

        private void ClearSelection()
        {
            SelectedMuscle = null;
        }

        #endregion
    }
}