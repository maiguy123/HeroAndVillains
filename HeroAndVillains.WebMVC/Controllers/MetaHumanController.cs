using HeroAndVillains.Services;
using System;
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
            var service = new MetaHumanServices(userId);
            return View(service);
        }
        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (MetaHumanCreate Model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}