using MyFitness.BL.Model;

namespace MyFitness.BL.Controller {
	public class ExercizeController : ControllerBase {
		private const string EXERCIZES_FILE_NAME = "exercizes.json";
		private const string ACTIVITIES_FILE_NAME = "activities.json";
		private readonly User user;
		public List<Exercize> Exercizes { get; }
		public List<Activity> Activitys { get; }

		public ExercizeController(User user) {
			this.user = user ?? throw new ArgumentException(nameof(user));
			Exercizes = GetAllExercises();
			Activitys = GetAllActivities();

		}

		public void Add(Activity activity, DateTime begin, DateTime end) {
			var act = Activitys.SingleOrDefault(a => a.Name == activity.Name);

			if(act == null) {
				Activitys.Add(activity);

				var exercise = new Exercize(begin, end, activity, user);
				Exercizes.Add(exercise);
			} else {
				var exercise = new Exercize(begin, end, activity, user);
				Exercizes.Add(exercise);
			}

			Save();
		}

		private List<Activity> GetAllActivities() {
			var activitiesDate = Load<Activity[]>(ACTIVITIES_FILE_NAME);
			if(activitiesDate != default(Activity[])) {
				return activitiesDate.ToList();
			} else {
				return new List<Activity>();
			}
		}

		private List<Exercize> GetAllExercises() {
			var exercizesDate = Load<Exercize[]>(EXERCIZES_FILE_NAME);
			if(exercizesDate != default(Exercize[])) {
				return exercizesDate.ToList();
			} else {
				return new List<Exercize>();
			}
		}

		private void Save() {
			base.Save<Exercize[]>(EXERCIZES_FILE_NAME, Exercizes.ToArray());
			base.Save<Activity[]>(ACTIVITIES_FILE_NAME, Activitys.ToArray());
		}
	}
}
