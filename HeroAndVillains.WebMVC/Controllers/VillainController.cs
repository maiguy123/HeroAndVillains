﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeroAndVillains.WebMVC.Controllers
{
    public class VillainController : Controller
    {
        // GET: Villain
        public ActionResult Index()
        {
            var model = new VillainListItem[0];
            return View(model);
        }
    }
}