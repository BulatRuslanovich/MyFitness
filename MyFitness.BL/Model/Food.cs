using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Food {
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public double Proteins { get; set; }
		[DataMember]
		public double Fats { get; set; }
		[DataMember]
		public double Carbohydrates { get; set; }
		[DataMember]
		public double Calories { get; set; }

		public virtual ICollection<Eating> Eatings { get; set; }

		public Food() {	}

		public Food(string Name) : this(Name, 0, 0, 0, 0) { }

		public Food(string Name, double Proteins, double Fats, double Carbohydrates, double Calories) {
			//TODO: checking

			this.Name = Name;
			this.Proteins = Proteins / 100.0;
			this.Fats = Fats / 100.0;
			this.Carbohydrates = Carbohydrates / 100.0;
			this.Calories = Calories / 100.0;
		}

		public override string ToString() {
			return Name;
		}
	}
}
