using ObservationCollections.Models;

namespace ObservationCollections.Services
{
    public static class DataRepository
    {
        #region Fields

        private static readonly List<Muscle> musclesList = new List<Muscle>();

        private static readonly List<User> usersList = new List<User>();

        #endregion

        #region Methods

        public static void FillFakeData()
        {
            // Create the central muscle list

            musclesList.Add(new Muscle { Name = "Biceps", BodyPart = "Arms" });
            musclesList.Add(new Muscle { Name = "Triceps", BodyPart = "Arms" });
            musclesList.Add(new Muscle { Name = "Chest", BodyPart = "Chest" });
            musclesList.Add(new Muscle { Name = "Quadriceps", BodyPart = "Legs" });
            musclesList.Add(new Muscle { Name = "Hamstrings", BodyPart = "Legs" });
            musclesList.Add(new Muscle { Name = "Latissimus", BodyPart = "Back" });

            // Create users and assign their muscles

            usersList.Add(new User
            {
                UserName = "Daniel",
                Password = "Daniel123",
                Email = "daniel@gmail.com",
                DateBirth = "2008-05-12",

                Muscles = new List<Muscle>
                {
                    musclesList[0],
                    musclesList[1],
                    musclesList[2]
                }
            });

            usersList.Add(new User
            {
                UserName = "John",
                Password = "John123",
                Email = "john@gmail.com",
                DateBirth = "2007-08-20",

                Muscles = new List<Muscle>
                {
                    musclesList[3],
                    musclesList[4]
                }
            });

            usersList.Add(new User
            {
                UserName = "Michael",
                Password = "Michael123",
                Email = "michael@gmail.com",
                DateBirth = "2006-11-03",

                Muscles = new List<Muscle>
                {
                    musclesList[5]
                }
            });
        }

        public static bool AddUser(User user)
        {
            if (usersList.Any(u =>
                u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            usersList.Add(user);
            return true;
        }

        public static User FindUser(string email, string password)
        {
            return usersList.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && u.Password == password);
        }

        public static bool EmailExists(string email)
        {
            return usersList.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // Add a muscle to a specific user's list.

        public static void AddMuscle(User user, Muscle muscle)
        {
            user.Muscles.Add(muscle);
        }

        // Remove a muscle from a specific user's list.

        public static void RemoveMuscle(User user, Muscle muscle)
        {
            user.Muscles.Remove(muscle);
        }

        #endregion
    }
}