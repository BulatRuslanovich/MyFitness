using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Eating {
		[DataMember]
		public DateTime Moment { get; set; }
		[DataMember]
		public Dictionary<Food, double> Foods { get; set; }
		[DataMember]
		public User User { get; set; }
		public Eating(User User) {
			this.User = User ?? throw new ArgumentNullException("Пользователь не может быть путым", nameof(User));
			Moment = DateTime.UtcNow;
			Foods = new Dictionary<Food, double>();
		}

		public void Add(Food product, double weight) {
			if(Foods == null) {
				Foods = new Dictionary<Food, double>();
			}

			var food = Foods.Keys.FirstOrDefault(f => f.Name.Equals(product.Name));


			if(food == null) {
				Foods.Add(product, weight);
			} else {
				Foods[product] += weight;
			}
		}
	}
}
