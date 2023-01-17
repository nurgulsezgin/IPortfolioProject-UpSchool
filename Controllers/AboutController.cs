using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout() { return View(); }
        [HttpPost]
        public ActionResult AddAbout(TblAbout p)
        {
            db.TblAbouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.TblAbouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout p)
        {
            var values = db.TblAbouts.Find(p.AboutId);
            values.Decription =p.Decription;
            values.ImageUrl = p.ImageUrl;
            values.FullName = p.FullName;
            values.ImageUrl=p.ImageUrl;
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
