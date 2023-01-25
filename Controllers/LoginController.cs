using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class LoginController : Controller
    {
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            var pass = HashSHA256.EncryptPassword(p.MemberPassword);
            var values = db.TblMembers.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == pass);//tek bir değer getirir
            if (values != null)
            {
                bool rememberMe = false;
                FormsAuthentication.SetAuthCookie(values.MemberMail, rememberMe);
                Session["MemberMail"] = p.MemberMail;
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(values);
        }
    }
}
