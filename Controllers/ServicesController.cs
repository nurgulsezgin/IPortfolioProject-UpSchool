using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;

using Newtonsoft.Json.Linq;

namespace IPortfolioProjects161022.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        /*
         ToList
        Add
        Remove
        Where
         */

        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblServices1.ToList();//Select*From tbl gibi   
            return View(values);
        }
        [HttpGet]//Sayfa sadece yüklenirse
        public ActionResult AddService()
        {
            return View();//Aynı sayfayı geri dön
        }

        [HttpPost]//Post İşlemi gerçekleşirse
        public ActionResult AddService(TblServices p)
        {
            db.TblServices1.Add(p);
            db.SaveChanges();//Ekleme işlemi yaptıktan sonra veri tabanına kaydetme işlemi yapmak için
            return RedirectToAction("Index");//Önceki sayfaya geri dön
        }
        public ActionResult DeleteService(int id)
        {
            var values = db.TblServices1.Find(id);
            db.TblServices1.Remove(values);
            db.SaveChanges();//Unutursan hata alırsın
            return RedirectToAction("Index");
        }
        [HttpGet]//ATTRİBUTE
        public ActionResult UpdateService(int id)//Güncelleme yaparken dikkat
        {
            var values = db.TblServices1.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(TblServices p)
        {
            var values = db.TblServices1.Find(p.ServicesId);
            values.Title = p.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
