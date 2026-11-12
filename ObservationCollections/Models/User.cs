using System.Collections.ObjectModel;

namespace ObservationCollections.Models
{
    public class User
    {
        #region Properties

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DateBirth { get; set; } = string.Empty;

        public ObservableCollection<Muscle> Muscles { get; set; }
    = new ObservableCollection<Muscle>();

        #endregion
    }
}