using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementMVC.Models.Entity;

namespace HotelManagementMVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DbHotelEntities db = new DbHotelEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(TblNewRegistry p)
        {
            db.TblNewRegistries.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}