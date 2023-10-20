using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    { 

        [TestMethod()]
        public void SaveTest()
        {
            string userName = Guid.NewGuid().ToString();

            var controller = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);

        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            string userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller_2 = new UserController(userName);

            Assert.AreEqual(userName, controller_2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller_2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller_2.CurrentUser.Weight);
            Assert.AreEqual(height, controller_2.CurrentUser.Height);
            Assert.AreEqual(gender, controller_2.CurrentUser.Gender.ToString());
        }
    }
}