using HeroAndVillains.Models;
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
        //GET
        public ActionResult Create()
        {
            return View();
        }
        // Add Method here VVVV
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HeroCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}