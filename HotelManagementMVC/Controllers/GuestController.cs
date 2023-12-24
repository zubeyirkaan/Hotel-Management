
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HotelManagementMVC.Models.Entity;

namespace HotelManagementMVC.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        // GET: Guest
        DbHotelEntities db = new DbHotelEntities();


        public ActionResult Index()
        {
            var guestemail = (string)Session["Email"];
            var guestdata = db.TblNewRegistries.Where(x => x.Email == guestemail).FirstOrDefault();
            return View(guestdata);
        }

        public ActionResult Reservations()
        {
            var guestemail = (string)Session["Email"];
            var datas = db.TblPreReservations.Where(x => x.Email == guestemail).ToList();
            return View(datas);
        }
        public ActionResult GuestInfoUpdate(TblNewRegistry p)
        {
            var guestdata = db.TblNewRegistries.Find(p.ID);
            guestdata.NameSurname = p.NameSurname;
            guestdata.Phone = p.Phone;
            guestdata.Password = p.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "HomePage");
        }

        public ActionResult Messages()
        {
            var guestemail = (string)Session["Email"];
            var messages = db.TblMessage2.Where(x => x.Reciever == guestemail).ToList();
            return View(messages);
        }
        public ActionResult SentMessages()
        {
            var guestemail = (string)Session["Email"];
            var messages = db.TblMessage2.Where(x => x.Sender == guestemail).ToList();
            return View(messages);
        }

        public ActionResult MessageDetail(int id)
        {
            var message = db.TblMessage2.Where(x => x.MessageID == id).FirstOrDefault();
            return View(message);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(TblMessage2 p)
        {
            var guestemail = (string)Session["Email"];
            p.Sender = guestemail;
            p.Reciever = "Admin";
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMessage2.Add(p);
            db.SaveChanges();
            return RedirectToAction("SentMessages");
        }
    }
}