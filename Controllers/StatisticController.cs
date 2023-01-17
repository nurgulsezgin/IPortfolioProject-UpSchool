using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.v1 = "Merhaba MVC"; //String veri

            //Referansların toplam sayısı
            //ViewBag.countTestimonial = db.TblTestimonials.Count();//Çok uzun o yüzden yorum satırı kullanalar ekle
            ViewBag.v2 = db.TblTestimonials.Count(); //Int veri

            //İstanbuldaki referansların sayısı
            //ViewBag.countTestimonialByCityİstanbul = db.TblTestimonials;
            ViewBag.v3 = db.TblTestimonials.Where(x => x.City == "İstanbul").Count();

            //Analist haricindeki kişi sayısı
            ViewBag.v4 = db.TblTestimonials.Where(x => x.Profession != "Analist").Count();

            //Şehir trabzon olan kişinin ismini getiren sorgu
            ViewBag.v5 = db.TblTestimonials.Where(x=>x.City=="Trabzon").Select(y=>y.FullName).FirstOrDefault();

            //Referansların ortalama maaşı
            ViewBag.v6 = db.TblTestimonials.Average(x=>x.Balance);
            return View();
        }
    }
}
