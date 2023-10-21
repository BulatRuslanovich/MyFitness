using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Exercize {
		[DataMember]
		public DateTime Start { get; set; }
		[DataMember]
		public DateTime Finish { get; set; }
		[DataMember]
		public Activity Activity { get; set; }
		[DataMember]
		public User User { get; set; }

		public Exercize(DateTime Start, DateTime Finish, Activity Activity, User User) {
			// TODO : checking
			this.Start = Start;
			this.Finish = Finish;
			this.Activity = Activity;
			this.User = User;
		}
	}
}
