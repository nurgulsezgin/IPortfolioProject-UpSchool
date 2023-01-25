using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class RegisterController : Controller
    {
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Yeni Üyelik Formu";
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            p.MemberPassword = HashSHA256.EncryptPassword(p.MemberPassword);
            db.TblMembers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
