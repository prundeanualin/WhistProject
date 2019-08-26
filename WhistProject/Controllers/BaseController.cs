using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhistProject.Models;

namespace WhistProject.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.Name;

                if (!string.IsNullOrEmpty(email))
                {
                    using (var db = new ApplicationDbContext())
                    {
                        string username = db.Player.Where(u => u.email == email).Single().username;
                        ViewData.Add("UserName", username);
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public BaseController()
        {
        }
    }
}