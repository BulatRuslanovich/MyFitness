using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFitness.BL.Model;


namespace MyFitness.BL.Controller.Tests {
	[TestClass()]
	public class ExercizeControllerTests {
		[TestMethod()]
		public void AddTest() {
			var userName = Guid.NewGuid().ToString();
			var activityName = Guid.NewGuid().ToString();
			var rnd = new Random();
			var userController = new UserController(userName);
			var exercizeController = new ExercizeController(userController.CurrentUser);
			var activity = new Activity(activityName, rnd.Next(10, 50));

			exercizeController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

			Assert.AreEqual(activityName, exercizeController.Activitys[0].Name);
		}
	}
}