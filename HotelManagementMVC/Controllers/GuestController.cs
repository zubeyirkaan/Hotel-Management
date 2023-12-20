
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementMVC.Models.Entity;

namespace HotelManagementMVC.Controllers
{
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
            ViewBag.a = guestemail;
            var datas = db.TblReservations.Where(x => x.Guest == 5).ToList();
            return View(datas);
        }
        public ActionResult GuestInfoUpdate(TblNewRegistry p)
        {
            var guest = db.TblNewRegistries.Find(p.ID);
            guest.NameSurname = p.NameSurname;
            guest.Phone = p.Phone;
            guest.Password = p.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}