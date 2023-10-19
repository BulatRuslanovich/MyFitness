using MyFitness.BL.Controller;
using MyFitness.BL.Model;
using System;

namespace MyFitness.CMD {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("MyFitness");
            Console.WriteLine("Enter user name");

            var name = Console.ReadLine();

            Console.WriteLine("Enter the gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter birthdate");

            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the weight");

            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the height");

            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}




