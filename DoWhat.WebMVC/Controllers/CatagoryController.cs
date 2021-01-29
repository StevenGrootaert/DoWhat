using DoWhat.Contracts;
using DoWhat.Models.CatagoryModels;
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
    public class CatagoryController : Controller
    {
        //private readonly ICatagoryService _catagoryService;
        //public CatagoryController(ICatagoryService catagoryService)
        //{
        //    _catagoryService = catagoryService;
        //}


        // GET: Catagory/index
        public ActionResult Index()
        {
            var service = CreateCatagoryService();
            var model = service.GetCatagories();
            return View(model.OrderBy(cat => cat.Name));
        }

        // GET: Catagory/Create
        public ActionResult Create()
        {
            return View();
        }

        // Catagory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CatagoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCatagoryService();

            if (service.CreateCatagory(model))
            {
                TempData["SaveResult"] = " You added a Catagory.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Catagory could not be added.");
            return View(model);
        }

        // Catagory/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateCatagoryService();
            var model = svc.GetCatagoryById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCatagoryService();
            var detail = service.GetCatagoryById(id);
            var model =
                new CatagoryEdit
                {
                    CatagoryId = detail.CatagoryId,
                    Name = detail.Name,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost] // Catagory/Edit/{id}
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CatagoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CatagoryId != id)
            {
                ModelState.AddModelError("", "Catagory ID Missmatch");
                return View(model);
            }

            var service = CreateCatagoryService();

            if (service.UpdateCatagory(model))
            {
                TempData["SaveResult"] = " Catagory was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Catagory could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCatagoryService();
            var model = svc.GetCatagoryById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCatagory(int id)
        {
            var service = CreateCatagoryService();
            service.DeleteCatagory(id);
            TempData["SaveResult"] = " Catagory was DELETED.";
            return RedirectToAction("Index");
        }


        // Helper Method
        private CatagoryService CreateCatagoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CatagoryService(userId);
            return service;
        }
    }
}