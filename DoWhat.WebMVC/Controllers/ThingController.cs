using DoWhat.Contracts;
using DoWhat.Data;
using DoWhat.Models.ThingModels;
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
        //private readonly IThingService _thingService;
        //public ThingController(IThingService thingService)
        //{
        //    _thingService = thingService;
        //}

        // GET: Thing/index
        public ActionResult Index()
        {
            var service = CreateThingService();
            var model = service.GetThings();
            return View(model.OrderBy(time => time.TimeAlloted));
        }

        public ActionResult IndexCompleted()
        {
            var service = CreateThingService();
            var model = service.GetAllCompletedThings();
            return View(model.OrderBy(time => time.TimeAlloted));
        }

        // GET: Thing/IndexByCatagory/{id}
        public ActionResult IndexByCatagory(int id)
        {
            var service = CreateThingService();
            var model = service.GetThingListByCatagory(id);
            return View(model.OrderBy(time => time.TimeAlloted));
        }

        /// -----------------------------------------------------------------------
        /// this is a lot like the create a thing but we're not saving it?
        
        public ActionResult SelectThing()
        {
            var service = CreateThingService();
            ViewBag.Catagories = service.CatagoriesToList();
            // redirect to action tot the SelectedThingIndex? need to take those submitted values and not save them but pass them
            return View(new ThingSelection());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectThing(ThingSelection model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateThingService();
            ViewBag.Catagories = service.CatagoriesToList();
            model.ThingsSelected = service.GetSelectedThing(model); // this line I don't get anymore -- this should fill out the list in the ThingSlection model??
            //return View(model.OrderBy(time => time.TimeAlloted));
            return View(model);
            //return RedirectToAction("SelectedThingIndex");
        }
         
        /// -----------------------------------------------------------------------

        // GET: Thing/Create
        public ActionResult Create()
        {
            var service = CreateThingService();
            //*var catagorySelectList = service.CatagoriesToList();
            //*ViewBag.Catagories = catagorySelectList;
            ViewBag.Catagories = service.CatagoriesToList();
            // shorter version version ^^

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
            ViewBag.Catagories = service.CatagoriesToList();
            var model =
                new ThingEdit
                {
                    ThingId = detail.ThingId,
                    Heading = detail.Heading,
                    CatagoryId = detail.CatagoryId,
                    TimeAllotted = detail.TimeAllotted
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

        [ActionName("Delete")]
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