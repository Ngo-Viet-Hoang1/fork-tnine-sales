﻿using System.Web.Mvc;

namespace tnine.Web.Host.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Angular");
        }
    }
}