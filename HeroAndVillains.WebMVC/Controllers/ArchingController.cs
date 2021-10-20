using HeroAndVillains.Models;
using HeroAndVillains.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    public class ArchingController : Controller
    {
        //GET: Note
        public ActionResult Index()
        {
            var service  = new ArchingServices();
            var model = service.GetArching();
            return View(model);

        }
        public ActionResult Create()
        {
            return View();
        }
        // Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (ArchingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new ArchingServices();
            if (service.CreateArching(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateArchingService();
            var model = svc.GetArchingById(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArchingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArchingID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateArchingService();

            if (service.UpdateArching(model))
            {
                TempData["SaveResult"] = "Your not was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);

        }


        public ActionResult Edit(int id)
        {
            var service = CreateArchingService();
            var detail = service.GetArchingById(id);
            var model =
                new ArchingEdit
                {
                    Story = detail.Story,

                };
            return View(model);
        }





        public ActionResult Delete(int id)
        {
            var svc = CreateArchingService();
            var model = svc.GetArchingById(id);
            return View(model);
        }




        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateArchingService();

            service.DeleteArching(id);

            TempData["SaveResult"] = "Your Arching was deleted";

            return RedirectToAction("Index");
        }

        public ArchingServices CreateArchingService()
        {
            var service = new ArchingServices();
            return service;
        }
    }
}