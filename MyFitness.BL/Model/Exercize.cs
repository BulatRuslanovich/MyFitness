using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Exercise {
		public int Id { get; set; }
		[DataMember]
		public DateTime Start { get; set; }
		[DataMember]
		public DateTime Finish { get; set; }
		public int ActivityId { get; set; }
		[DataMember]
		public virtual Activity Activity { get; set; }
		public int UserId { get; set; }
		[DataMember]
		public virtual User User { get; set; }

		public Exercise() { }

		public Exercise(DateTime Start, DateTime Finish, Activity Activity, User User) {
			// TODO : checking
			this.Start = Start;
			this.Finish = Finish;
			this.Activity = Activity;
			this.User = User;
		}
	}
}
