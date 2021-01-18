using DoWhat.Models.ResourceModels;
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
    public class ResourceController : Controller
    {
        public ActionResult Index()
        {
            var service = CreateResourceService();
            var model = service.GetResources();
            return View(model);
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // Resource/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateResourceService();

            if (service.CreateResource(model))
            {
                TempData["SaveResult"] = " You added a Resource.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Resource could not be added.");
            return View(model);
        }

        // Resource/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateResourceService();
            var model = svc.GetResourceById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateResourceService();
            var detail = service.GetResourceById(id);
            var model =
                new ResourceEdit
                {
                    ResourceId = detail.ResourceId,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost] // Resource/Edit/{id}
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResourceEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ResourceId != id)
            {
                ModelState.AddModelError("", "Resource ID Missmatch");
                return View(model);
            }

            var service = CreateResourceService();

            if (service.UpdateResource(model))
            {
                TempData["SaveResult"] = " Resource was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Resource could not be updated.");
            return View(model);
        }

        [ActionName("Delete")] // do other things need action names?? 
        public ActionResult Delete(int id)
        {
            var svc = CreateResourceService();
            var model = svc.GetResourceById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteResource(int id)
        {
            var service = CreateResourceService();
            service.DeleteResource(id);
            TempData["SaveResult"] = " Resource was DELETED.";
            return RedirectToAction("Index");
        }

        // helper method
        private ResourceService CreateResourceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ResourceService(userId);
            return service;
        }
    }
}