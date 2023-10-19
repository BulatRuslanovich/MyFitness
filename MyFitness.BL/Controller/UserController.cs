using MyFitness.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFitness.BL.Controller
{
    
    public class UserController
    {
        public User User { get; }

        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate)) {
#pragma warning disable SYSLIB0011
                formatter.Serialize(file, User);
#pragma warning restore SYSLIB0011 
            }
        }
        
        public UserController() {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
#pragma warning disable SYSLIB0011 
                if (formatter.Deserialize(file) is User user)
                {
                    this.User = user;
                }

                // TODO: write else
       
#pragma warning restore SYSLIB0011 

            }
        }
    }
}
