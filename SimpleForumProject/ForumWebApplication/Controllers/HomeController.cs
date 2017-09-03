using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            string result = "You are not authorized";
            if (User.Identity.IsAuthenticated)
            {
                result = "Your login: " + User.Identity.Name;
            }
            return result;
        }

        [Authorize]
        public string GotIt()
        {
            return "Authorized";
        }
    }
}