using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var model = new HeroAndVillains.Models.TeamListItem[0];
            return View(model);
        }
    }
}