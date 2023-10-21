using MyFitness.BL.Controller;
using MyFitness.BL.Model;
using System;
using System.Reflection.Metadata;

namespace MyFitness.CMD {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("\"MyFitness app\"");
            Console.Write("Enter user name: ");

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
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

            Console.WriteLine("What you want to do?");
            Console.WriteLine("E - Enter the eating");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                Console.WriteLine();
                var productInfo = EnterEating();
                eatingController.Add(productInfo.Item1, productInfo.Item2);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }

        private static (Food, double) EnterEating() {
            Console.Write("Enter the name of product: ");
            var productName = Console.ReadLine() ?? "noName";

            var calories = ParseDouble("calorie content");
            var proteins = ParseDouble("amount of proteins");
            var fats = ParseDouble("amount of fats");
            var carbs = ParseDouble("amount of carbs");
            var weight = ParseDouble("weight of product");
            return (new Food(productName, proteins, fats, carbs, calories), weight);

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




