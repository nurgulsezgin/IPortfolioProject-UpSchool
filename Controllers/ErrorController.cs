using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPortfolioProjects161022.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Page404()
        {
            return View();
        }
    }
}
