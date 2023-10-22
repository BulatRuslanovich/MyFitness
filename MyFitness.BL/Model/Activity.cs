using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Activity {
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }
		public virtual ICollection<Exercise> Exercizes { get; set;}
		[DataMember]
		public double CaloriesPerMinute { get; set; }

		public Activity() { }
		public Activity(string Name, double CaloriesPerMinute) {
			//TODO : Checking data
			this.Name = Name;
			this.CaloriesPerMinute = CaloriesPerMinute;
		}

		public override string ToString() {
			return Name;
		}
	}
}
