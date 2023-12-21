
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
            //ViewBag.a = guestemail;
            var guestid = db.TblNewRegistries.Where(x => x.Email == guestemail).Select(y => y.ID).FirstOrDefault();
            ViewBag.a = guestid;
            var datas = db.TblReservations.Where(x => x.Guest == guestid).ToList();
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
    }
}