using MyFitness.BL.Model;

namespace MyFitness.BL.Controller {
	public class ExercizeController : ControllerBase {
		private readonly User user;
		public List<Exercise> Exercises { get; }
		public List<Activity> Activitys { get; }

		public ExercizeController(User user) {
			this.user = user ?? throw new ArgumentException(nameof(user));
			Exercises = GetAllExercises();
			Activitys = GetAllActivities();

		}

		public void Add(Activity activity, DateTime begin, DateTime end) {
			var act = Activitys.SingleOrDefault(a => a.Name == activity.Name);

			if(act == null) {
				Activitys.Add(activity);

				var exercise = new Exercise(begin, end, activity, user);
				Exercises.Add(exercise);
			} else {
				var exercise = new Exercise(begin, end, activity, user);
				Exercises.Add(exercise);
			}

			Save();
		}

		private List<Activity> GetAllActivities() {
			return Load<Activity>() ?? new List<Activity>();
		}

		private List<Exercise> GetAllExercises() {
			return Load<Exercise>() ?? new List<Exercise>();
		}

		private void Save() {
			Save(Activitys);
			Save(Exercises);
		}
	}
}
