using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRPG.MVC.Controllers;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        UserController userController;
        UserClient userclient;
        [TestInitialize]
        public void SetUp()
        {
            userController = new UserController();
            userclient = new UserClient();
        }


        [TestMethod]
        public void ServiceReferenceTest()
        {
            Assert.IsNotNull(userclient);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            User user = new User()
            {
                Active = true,
                Adventures = null,
                Characters = null,
                HashedPassword = "Random",
                IsGameMaster = false,
                UserName = "Elyas"
            };
            userclient.Create(user);

            Assert.AreEqual(user.UserName, userclient.Find(user.UserName).UserName);

        }

        [TestMethod]
        public void FindUserTest()
        {
            Assert.IsNotNull(userclient.Find("Elyas"));
        }
    }
}
