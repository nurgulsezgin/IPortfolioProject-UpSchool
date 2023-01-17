using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;
namespace IPortfolioProjects161022.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UPSchoolDbPortfolioEntities db=new UPSchoolDbPortfolioEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServicePartial()
        {
            var values = db.TblServices1.ToList();
            return PartialView(values);
        }
    }
}
