using MyFitness.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFitness.BL.Controller
{
    
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;


        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя не может быть путстым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Check

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 
                if (file.Length > 0 && formatter.Deserialize(file) is List<User> users)
                {
                    return users;
                } else
                {
                    return new List<User>();
                }

               

#pragma warning restore SYSLIB0011

            }
        }

        private void Save()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate)) {
#pragma warning disable SYSLIB0011
                formatter.Serialize(file, Users);
#pragma warning restore SYSLIB0011 
            }
        }
        

    }
}
