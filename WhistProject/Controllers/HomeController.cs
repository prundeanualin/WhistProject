﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhistProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is whist ?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the developers";

            return View();
        }
    }
}