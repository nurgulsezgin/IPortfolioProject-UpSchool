using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

using IPortfolioProjects161022.Models.Entities;

namespace IPortfolioProjects161022.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        UPSchoolDbPortfolioEntities db = new UPSchoolDbPortfolioEntities();
        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.tblMessages.Where(x => x.ReceiverMail == mail).ToList();
            return View(values);
        }
        public ActionResult OutBox()
        {
            var mail = Session["MemberMail"].ToString();
            var values = db.tblMessages.Where(x => x.SenderMail == mail).ToList();
            return View(values);
        }
        [HttpPost]
        public ActionResult SendMessage(tblMessage p)
        {
            var mail = Session["MemberMail"].ToString();

            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderMail = mail;
            p.SenderNameSurname = db.TblMembers.Where(x=>x.MemberMail==mail).Select(y=>y.MemberName+" "+y.MemberSurname).FirstOrDefault();
            p.ReceiverMail = db.TblMembers.Where(x=>x.MemberMail==p.ReceiverMail).Select(y=>y.MemberName+" "+y.MemberSurname).FirstOrDefault();

            db.tblMessages.Add(p);
            db.SaveChanges();
            return RedirectToAction("OutBox");
        }
        public ActionResult MessageDetails()
        {
            return View();
        }
    }
}
