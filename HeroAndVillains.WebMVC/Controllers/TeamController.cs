using HeroAndVillains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var model = new HeroAndVillains.Models.TeamListItem[0];
            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        // Add Method here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}