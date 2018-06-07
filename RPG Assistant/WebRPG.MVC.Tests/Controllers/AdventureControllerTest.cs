using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Tests.Controllers
{
    [TestClass]
    public class AdventureControllerTest
    {
        UserClient userclient;
        AdventureClient adventureClient;
        [TestInitialize]
        public void SetUp()
        {
            userclient = new UserClient();
            adventureClient = new AdventureClient();
        }


        [TestMethod]
        public void AdventureServiceTest()
        {
            Assert.IsNotNull(userclient);
        }

        [TestMethod]
        public void CreateAdventureTest()
        {
            Adventure adventure = new Adventure()
            {
                Active = true,
                Date = DateTime.Now,
                Logbook = "The war has yet to end, and will be continued in the next mission",
                MaxPlayers = 3,
                Name = "War At The Riverside"
            };
            adventureClient.Create(adventure);

            Assert.AreEqual(adventure.Name, adventureClient.Find(adventure.Name).Name);
        }


        [TestMethod]
        public void FindAdventureTest()
        {
            Assert.IsNotNull(adventureClient.Find("RandomBullshit"));
        }

    }
}
