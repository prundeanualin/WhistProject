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
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string firstName = user.First_Name;
                    string lastName = user.Last_Name;
                    string email = user.Email;
                    ViewData.Add("Email", email);
                    ViewData.Add("First Name", firstName);
                    ViewData.Add("Last Name", lastName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
        public BaseController()
        { }
    }
}