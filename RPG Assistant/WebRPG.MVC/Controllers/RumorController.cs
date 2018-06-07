using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRPG.MVC.Models.RumorModel;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Controllers
{
    public class RumorController : Controller
    {
        // GET: Rumor
        public ActionResult ShowRumors()
        {
            return View();
        }

        // GET: Rumor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rumor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rumor/Create
        [HttpPost]
        public ActionResult Create(CreateRumorModel CreateModel)
        {
            try
            {
                RumorClient rumorClient = new RumorClient();

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "An error Occured. You are being redirected to Show Rumors.");
                    return RedirectToAction("ShowRumors");
                }
                else
                {
                    Rumor rumor = new Rumor
                    {
                        Name = CreateModel.Name,
                        Date = CreateModel.Date,
                        Description = CreateModel.Description
                    };
                    //rumorClient.Create(rumor);
                }
                

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rumor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rumor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rumor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rumor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

                   // rumorClient.Create(rumor);
