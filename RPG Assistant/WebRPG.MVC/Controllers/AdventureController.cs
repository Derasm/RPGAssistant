using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRPG.MVC.UserServiceReference;
using WebRPG.MVC.Models.AdventureModel;


namespace WebRPG.MVC.Controllers
{

    [Authorize]
    public class AdventureController : Controller
    {
        private AdventureClient adventureClient = new AdventureClient();

        // GET: Adventure
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdventureScreen()
        {
            var adventures = new List<Adventure>();
            adventures = adventureClient.GetAll();
            return View(adventures);
        }

        public ActionResult AdventureScreenGUI()
        {
            return View("AdventureScreenGUI");
        }
        [HttpGet]
        public void JoinAdventure(string adventureName)
        {
            //check list if players in adventure has same name as joining player
            //if same name, dont do anything.
            //if not, add the user to the adventure. 
            
            UserClient client = new UserClient();
            try
            {
                User user = client.Find(User.Identity.Name);
                Adventure adventure = adventureClient.Find(adventureName);
                if (adventure.Players.Count >= adventure.MaxPlayers)
                {
                    ModelState.AddModelError("", "This adventure is not available for joining.");
                }
                if (adventure.Players.FirstOrDefault(x => x.UserName == user.UserName) == null)
                {
                    adventure.Players.Add(user);
                    int a = adventureClient.Update(adventure);
                    Adventure Adventure2 = adventureClient.Find(adventure.Name);
                }
                else
                {
                    ModelState.AddModelError("", "You are already on that adventure.");
                }
            }
            catch (Exception Ex)
            {
                ModelState.AddModelError("", "Failed to join adventure, no open spots.");
            }
        }
        //create adventure
        public ActionResult CreateAdventure()
        {
            CreateAdventureVM model = new CreateAdventureVM
            {
                Date = DateTime.Today,
                MaxPlayers = 2,
                Name = "Tester"
            };
            return View("CreateAdventure", model);
        }
        [HttpPost]
        public ActionResult CreateAdventure(CreateAdventureVM model)
        {
            if (model.MaxPlayers <= 0)
            {
                ModelState.AddModelError("", "Max players must be more than 0.");
                return View("CreateAdventure", model);
            }
            if (model.Date < DateTime.Today)
            {
                ModelState.AddModelError("", "please choose a date from today and onwards.");
                return View("CreateAdventure", model);
            }
            UserClient client = new UserClient();
            User Auser = client.Find(User.Identity.Name);

            if (adventureClient.Find(model.Name) != null)
            {
                ModelState.AddModelError("", "An Adventure with that name already exists.");
                return View("CreateAdventure");
            }
            try
            {
                {
                    Adventure adventure = new Adventure
                    {
                        Name = model.Name,
                        Date = model.Date,
                        MaxPlayers = model.MaxPlayers,
                        Players = new List<User>()
                    };
                    adventure.Players.Add(Auser);
                    adventureClient.Create(adventure);
                }
                /*
                 * adventure - har user - tag user ID  sæt user ID reference på adventure. 
                 */
                return RedirectToAction("AdventureScreen");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ModelState.AddModelError("", "Adventure was not created. See exception for details.");
                return View();
            }
        }
    }
}