using MyFitness.BL.Controller;
using MyFitness.BL.Model;
using System.Globalization;
using System.Resources;

namespace MyFitness.CMD {
	class Program {
		static void Main(string[] args) {
			var culture = CultureInfo.CreateSpecificCulture("en-us");
			var resourceManager = new ResourceManager("MyFitness.CMD.Languages.Messages", typeof(Program).Assembly);

			Console.WriteLine(resourceManager.GetString("HelloMsg", culture));
			Console.Write(resourceManager.GetString("EnterName", culture));

			var name = Console.ReadLine();

			var userController = new UserController(name);
			var eatingController = new EatingController(userController.CurrentUser);
			var execiseControler = new ExercizeController(userController.CurrentUser);
			if(userController.IsNewUser) {
				Console.Write(resourceManager.GetString("EnterGender", culture));
				var gender = Console.ReadLine();

				DateTime birthDate = ParseDate("birth date");
				double weight = ParseDouble("weight");
				double height = ParseDouble("height");
				userController.SetNewUserData(gender, birthDate, weight, height);

			}

			Console.WriteLine(userController.CurrentUser);

			while (true) {
				Console.WriteLine("What you want to do?");
				Console.WriteLine("E - Enter the eating");
				Console.WriteLine("A - Enter the exercize");
				Console.WriteLine("Q - exit");

				var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key) {
					case ConsoleKey.E:
						var productInfo = EnterEating();
						eatingController.Add(productInfo.Food, productInfo.Weight);

						foreach(var item in eatingController.Eating.Foods) {
							Console.WriteLine($"{item.Key} - {item.Value}");
						}

						break;
					case ConsoleKey.A:
						var exercizeData = EnterExercise();
						execiseControler.Add(exercizeData.Activity, exercizeData.begin, exercizeData.end);
		
						foreach(var item in execiseControler.Exercizes) {
							Console.WriteLine($"{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
						}

						break;
					case ConsoleKey.Q:
						Environment.Exit(0);
						break;
				}
			}
		}

		private static (DateTime begin, DateTime end, Activity Activity) EnterExercise() {
			Console.Write("Enter the exercize: ");
			var exerciseName = Console.ReadLine() ?? "noName";
			var energy = ParseDouble("power consumption");

			var begin = ParseDate("start of exercize");
			var end = ParseDate("end of exercize");
			var activity = new Activity(exerciseName, energy);

			return (begin, end, activity);

        }

		private static (Food Food, double Weight) EnterEating() {
			Console.Write("Enter the name of product: ");
			var productName = Console.ReadLine() ?? "noName";

			var calories = ParseDouble("calorie content");
			var proteins = ParseDouble("amount of proteins");
			var fats = ParseDouble("amount of fats");
			var carbs = ParseDouble("amount of carbs");
			var weight = ParseDouble("weight of product");
			return (new Food(productName, proteins, fats, carbs, calories), weight);

		}

		private static DateTime ParseDate(string value) {
			while(true) {
				Console.Write($"Enter the {value} (dd.MM.yyyy): ");
				if(DateTime.TryParse(Console.ReadLine(), out DateTime date)) {
					return date;
				} else {
					Console.WriteLine("Wrong format!");
				}

			}
		}



		private static double ParseDouble(string name) {
			while(true) {
				Console.Write($"Enter the {name}: ");
				if(double.TryParse(Console.ReadLine(), out double value)) {
					return value;
				} else {
					Console.WriteLine("Wrong format!");
				}

			}
		}
	}
}




