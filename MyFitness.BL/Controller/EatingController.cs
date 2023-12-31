﻿using MyFitness.BL.Model;

namespace MyFitness.BL.Controller {
	public class EatingController : ControllerBase {
		private readonly User user;
		public List<Food> Foods { get; }
		public Eating Eating { get; }

		public EatingController(User user) {
			this.user = user ?? throw new ArgumentNullException("Пользователь не может быть путым", nameof(user));

			Foods = GetAllFoods();
			Eating = GetEating();
		}

		public void Add(Food food, double weight) {
			var product = Foods.SingleOrDefault(f => f.Name == food.Name);

			if(product == null) {
				Foods.Add(food);
				Eating.Add(food, weight);
				Save();
			} else {
				Eating.Add(product, weight);
				Save();
			}
		}

		private List<Food> GetAllFoods() {
			return Load<Food>() ?? new List<Food>();
		}

		private void Save() {
			Save(Foods);
			Save(new List<Eating>() { Eating });
		}

		private Eating GetEating() {
			return Load<Eating>().FirstOrDefault() ?? new Eating(user);
		}
	}
}
