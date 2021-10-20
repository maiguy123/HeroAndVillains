using HeroAndVillains.Services;
using HeroAndVillains.Models;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    public class MetaHumanController : Controller
    {
        // GET: MetaHuman
        public ActionResult Index()
        {
            var service = new MetaHumanServices();
            var model = service.GetMetaHuman();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        //Doing 
        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MetaHumanCreate model)
        {
            if (!ModelState.IsValid) { 
                return View(model);
            }
            var service = new MetaHumanServices();
            if (service.CreateMetaHuman(model)) { 
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateMetaHumanService();
            var model = svc.GetMetaHumansById(id);

            return View(model);
        }
        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, MetaHumanEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MetaHumanID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMetaHumanService();
            
            if (service.UpdateMetaHuman(model))
            {
                TempData["SaveResult"] = "Your not was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);

        }



        public ActionResult Edit(int id)
        {
            var service = CreateMetaHumanService();
            var detail = service.GetMetaHumansById(id);
            var model =
                new MetaHumanEdit
                {
                    PowerType = detail.PowerType,
                    Rating = detail.Rating,
                    Home = detail.Home,

                };
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateMetaHumanService();
            var model = svc.GetMetaHumansById(id);
            return View(model);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMetaHumanService();

            service.DeleteMetaHuman(id);

            TempData["SaveResult"] = "Your MetaHuman was deleted";

            return RedirectToAction("Index");
        }
        public MetaHumanServices CreateMetaHumanService()
        {
            var service = new MetaHumanServices();
            return service;
        }


    }

}