using MyFitness.BL.Controller;
using MyFitness.BL.Model;
using System;

namespace MyFitness.CMD {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\"MyFitness app\"");
            Console.Write("Enter user name: ");

            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter the gender: ");
                var gender = Console.ReadLine();

  
                DateTime birthDate = ParseDate();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");           
                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
        }

        private static DateTime ParseDate()
        {
            while (true)
            {
                Console.Write("Enter the birthdate (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Wrong format!");
                }

            }
        }



        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter the {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Wrong format!");
                }

            }
        }
    }
}




