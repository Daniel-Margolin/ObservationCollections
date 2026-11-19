using System.Text.RegularExpressions;
using System.Windows.Input;
using ObservationCollections.Services;

namespace ObservationCollections.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        #region Fields

        private string email = string.Empty;
        private string password = string.Empty;
        private string emailError = string.Empty;
        private string passwordError = string.Empty;

        #endregion

        #region Properties

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged();
            }
        }

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SignInCommand { get; }
        public ICommand RegisterCommand { get; }

        #endregion

        #region Constructor

        public LogInViewModel()
        {
            SignInCommand = new Command(async () => await SignIn());
            RegisterCommand = new Command(async () => await Register());
        }

        #endregion

        #region Methods

        private async Task SignIn()
        {
            EmailError = "";
            PasswordError = "";

            if (string.IsNullOrWhiteSpace(Email))
            {
                EmailError = "Email can't be empty.";
                return;
            }

            if (!Regex.IsMatch(Email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                EmailError = "Please enter a valid email address.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordError = "Password can't be empty.";
                return;
            }

            // Find the user in the repository.

            var user = await DataRepository.FindUserAsync(Email, Password);

            if (user == null)
            {
                PasswordError = "Incorrect email or password.";
                return;
            }

            // Navigate to the MuscleList page.

            await Application.Current.MainPage.Navigation.PushAsync(
                new ObservationCollections.Views.MuscleList(user));
        }

        private async Task Register()
        {
            await Application.Current.MainPage.Navigation.PushAsync(
                new ObservationCollections.Views.Register());
        }

        #endregion
    }
}