using System;
using System.Web.Mvc;
using WebRPG.MVC.Models.User;
using WebRPG.MVC.Models.UserModel;
using WebRPG.MVC.UserServiceReference;
using System.Web.Security;
using System.Security.Claims;
using System.Web;
using System.Text;
using System.Collections.Generic;

namespace WebRPG.MVC.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private UserClient userClient = new UserClient();

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("AdventureScreen","Adventure");
            else return View();
        }

        // GET: User/Create
        public ActionResult Registration()
        {
            return View();
        }

        //GET: GMLogin Screen
        public ActionResult GMLogin()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult GMLogin(LoginViewModel loginModel)
        {
            try
            {
                //changed method to check on username instead of first getting list, then checking.
                User user = userClient.FindUserWithPassword(loginModel.Username, loginModel.Password);
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }
                else
                {
                    if (user != null)
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, user.UserName)
                            }, "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);
                        return RedirectToAction("AdventureScreen", "Adventure");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong.");
                    }

                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrMessage = ex.Message;
                ViewBag.ErrMsg = "There was an exception. You are being redirected to the login Screen!";
                return View("Login");
            }
        }

        //GET: userLogin Screen
        public ActionResult UserLogin()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult UserLogin(LoginViewModel loginModel)
        {
            try
            {
                //List<User> allUsers = userClient.GetAll();
                //Char[] usernameArray = loginModel.Username.ToCharArray();
                //User user = null;
                User user = userClient.FindUserWithPassword(loginModel.Username, loginModel.Password);


                //if (Char.IsLower(usernameArray[0]))
                //{
                //    user = allUsers.Find(x => Char.IsLower(x.UserName[0]) == true);
                //}
                //else
                //{
                //    user = allUsers.Find(x => Char.IsUpper(x.UserName[0]).Equals(loginModel.Username[0]));

                //}
                //User user = userClient.Find(loginModel.Username);
                if (user != null)
                {
                    if (!user.IsGameMaster)
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, user.UserName)
                            }, "ApplicationCookie");

                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);
                        return RedirectToAction("AdventureScreen", "Adventure");
                    }
                    else
                    {
                        ViewBag.Redirection = "You are a GM, please choose the correct login screen. You are being redirected to the start screen";
                        RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
                return RedirectToAction("AdventureScreen", "Adventure");
            }
            catch (Exception ex)
            {
                ViewBag.ErrMessage = ex.Message;
                ViewBag.ErrMsg = "There was an exception. You are being redirected to the login Screen!";
                return View("Login");
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "User");
        }
        // POST: User/Create
        [HttpPost]
        public ActionResult Registration(RegistrationViewModel model)
        {

            try
            {
                if (model.IsGM && model.IsPlayer)
                {
                    ModelState.AddModelError("", "You cant be both player and GM.");
                    return View();
                }
                User userTemp = userClient.Find(model.Name);

                if (userTemp != null)
                {
                    ModelState.AddModelError("", "A user with this username already exist.");
                    return View();
                }
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        UserName = model.Name,
                        HashedPassword = model.Password,
                        Active = true
                    };
                    user.HashedPassword = model.Password;
                    if (model.IsGM) user.IsGameMaster = model.IsGM;
                    else if (model.IsPlayer) user.IsGameMaster = false;
                    userClient.Create(user);
                }
                return RedirectToAction("Index");
            }
            catch (NotFiniteNumberException ex)
            {
                
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(EditUserViewModel editModel)
        {
            User user = userClient.Find(editModel.EditUser.Name);

            editModel.User = user;
            return View(editModel);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditUserModel editModel)
        {
            try
            {


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
