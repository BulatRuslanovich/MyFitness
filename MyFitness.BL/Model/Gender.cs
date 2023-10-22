using System.Runtime.Serialization;

namespace MyFitness.BL.Model {
	[DataContract]
	public class Gender {
		public int Id { get; set; }
		[DataMember]
		public string Name { get; set; }

		public virtual ICollection<User> Users { get; set; }

		public Gender() { }

		public Gender(string Name) {
			if(string.IsNullOrWhiteSpace(Name)) {
				throw new ArgumentNullException("Имя пола не может быть пустым.", nameof(Name));
			}

			this.Name = Name;
		}

		public override string ToString() {
			return Name;
		}
	}
}
