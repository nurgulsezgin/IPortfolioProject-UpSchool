using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.TblMembers.Where(x => x.MemberMail == mail).FirstOrDefault();
            ViewBag.name = values.MemberName;
            ViewBag.surname = values.MemberSurname;
            ViewBag.id = values.MemberID;

            return View();
        }
    }
}
