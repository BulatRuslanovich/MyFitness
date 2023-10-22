using MyFitness.BL.Model;

namespace MyFitness.BL.Controller {
	public class UserController : ControllerBase {
		public List<User> Users { get; }
		public User CurrentUser { get; }
		public bool IsNewUser { get; } = false;


		public UserController(string userName) {
			if(string.IsNullOrWhiteSpace(userName)) {
				throw new ArgumentNullException("Имя не может быть путстым", nameof(userName));
			}

			Users = GetUsersData();
			CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

			if(CurrentUser == null) {
				CurrentUser = new User(userName);    
				Users.Add(CurrentUser);
				IsNewUser = true;
				Save();
			}
		}

		public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1) {
			// TODO: Check

			CurrentUser.Gender = new Gender(genderName);
			CurrentUser.BirthDate = birthDate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;
			Save();

		}

		private List<User> GetUsersData() {
			return Load<User>() ?? new List<User>();
		}

		private void Save() {
			Save(Users);
		}


	}
}
