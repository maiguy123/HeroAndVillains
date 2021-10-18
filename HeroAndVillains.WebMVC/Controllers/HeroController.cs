using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    [Authorize]
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult Index()
        {
            var model = new HeroAndVillains.Models.HeroListItem[0];
            return View(model);
        }
    }
}