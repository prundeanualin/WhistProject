using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WhistProject.Models;

namespace WhistProject.Controllers
{
    public class LobbyController : Controller
    {

        // GET: Lobby
        public ActionResult Index()
        {
            ViewBag.Message = "Time to play";
            return View();
        }
    }
}