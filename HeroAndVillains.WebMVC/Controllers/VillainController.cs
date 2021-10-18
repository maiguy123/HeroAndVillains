using HeroAndVillains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    [Authorize]
    public class VillainController : Controller
    {
        // GET: Villain
        public ActionResult Index()
        {
            var model = new VillainListItem[0];
            return View(model);
        }

        // GET 
        public ActionResult Create()
        {
            return View();
        }
        //Add methos here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (VillainCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}