using DoWhat.Models;
using DoWhat.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoWhat.WebMVC.Controllers
{
    [Authorize]
    public class ThingController : Controller
    {
        // GET: Thing/index
        public ActionResult Index()
        {
            var service = CreateThingService();
            var model = service.GetThings();
            return View(model);
        }

        // GET: Thing/Create
        public ActionResult Create()
        {
            return View();
        }

        // Thing/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThingCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateThingService();

            if (service.CreateThing(model))
            {
                TempData["SaveResult"] = " You added a Thing.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Thing could not be added.");
            return View(model);
        }

        // Thing/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateThingService(); 
            var model = svc.GetThingById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateThingService();
            var detail = service.GetThingById(id);
            var model =
                new ThingEdit
                {
                    ThingId = detail.ThingId,
                    Heading = detail.Heading,
                };
            return View(model);
        }

        [HttpPost] // Thing/Edit/{id}
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ThingEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ThingId != id)
            {
                ModelState.AddModelError("", "Thing ID Missmatch");
                return View(model);
            }

            var service = CreateThingService();

            if (service.UpdateThing(model))
            {
                TempData["SaveResult"] = " Thing was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thing could not be updated.");
            return View(model);
        }


        [ActionName("Delete")] // do other things need action names?? 
        public ActionResult Delete(int id)
        {
            var svc = CreateThingService();   
            var model = svc.GetThingById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteThing(int id)
        {
            var service = CreateThingService();
            service.DeleteThing(id);
            TempData["SaveResult"] = " Thing was DELETED.";
            return RedirectToAction("Index");
        }

        // helper method
        private ThingService CreateThingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThingService(userId);
            return service;
        }
    }
}