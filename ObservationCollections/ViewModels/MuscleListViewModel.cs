using System.Collections.ObjectModel;
using ObservationCollections.Models;

namespace ObservationCollections.ViewModels
{
    public class MuscleListViewModel : ViewModelBase
    {
        #region Fields

        private Muscle? selectedMuscle;

        private User currentUser;

        #endregion

        #region Properties

        public ObservableCollection<Muscle> Muscles { get; set; }

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

            Muscles = currentUser.Muscles;

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

            Muscles.Add(newMuscle);

            SelectedMuscle = newMuscle;
        }

        private void DeleteMuscle()
        {
            if (SelectedMuscle == null)
            {
                return;
            }

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
