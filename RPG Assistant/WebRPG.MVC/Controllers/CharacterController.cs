using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRPG.MVC.UserServiceReference;
using WebRPG.MVC.Models.CharacterModel;
using System.Net;

namespace WebRPG.MVC.Controllers
{
    public class CharacterController : Controller
    {
        private CharacterClient characterClient = new CharacterClient();
        private UserClient userClient = new UserClient();
        // GET: Character
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CharacterView()
        {

            //List<Character> characters = new List<Character>();
            //characters = characterClient.GetAll();
            User user = userClient.Find(User.Identity.Name);
            //user.Characters = characters.FindAll(character => character.UserID == user.ID);
            return View(user.Characters);
        }

        public ActionResult CreateCharacterView()
        {
            return View("CreateCharacterView");
        }

        [HttpPost]
        public ActionResult CreateCharacterView(CreateCharacter cmodel)
        {
            User user = userClient.Find(User.Identity.Name);
            if (characterClient.Find(cmodel.Name) != null)
            {
                ModelState.AddModelError("", "This Character already exist");
                return RedirectToAction("CreateCharacterView", user.Characters);
            }
            try
            {

                Character character = new Character
                {
                    Name = cmodel.Name,
                    Level = cmodel.Level,
                    Class = cmodel.Class,
                    BackGroundStory = cmodel.BackGroundStory,
                };
                user.Characters.Add(character);
                userClient.Update(user);
                characterClient.Create(character); // does not set the foreign key as intended.


                return RedirectToAction("CharacterView", user.Characters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("CreateCharacterView");
            }

        }

        [HttpGet]
        public ActionResult CharacterUpdateView(string Name)
        {
            if (Name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            else
            {
                Character character = characterClient.Find(Name);
                if (character == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                else
                {
                    UpdateCharacter uModel = new UpdateCharacter();
                    uModel.Name = character.Name;
                    uModel.Level = character.Level;
                    uModel.Class = character.Class;
                    uModel.BackGroundStory = character.BackGroundStory;
                    return View(uModel);
                }
            }
        }
        // metoden er ikke færdig da den nede på serveren får en nullpointException.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CharacterUpdateView(UpdateCharacter uModel)
        {
            try
            {
                Character character = characterClient.Find(uModel.Name);
                characterClient.Update(character);

                return RedirectToAction("CharacterView");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View("CharacterUpdateView");
            }
        }

    }
}