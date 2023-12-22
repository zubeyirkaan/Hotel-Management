using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementMVC.Models.Entity;
namespace HotelManagementMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbHotelEntities db = new DbHotelEntities();

        public ActionResult About()
        {
            var datas = db.TblAbouts.ToList();
            return View(datas);
        }


        public PartialViewResult PartialFooter()
        {
            var bookedroom = db.TblRooms.Where(x => x.Status != 1).Count();
            ViewBag.d = bookedroom;
            var emptyroom = db.TblRooms.Where(x => x.Status == 1).Count();
            ViewBag.b = emptyroom;
            return PartialView();
        }

        public PartialViewResult PartialSocialMedia()
        {
            return PartialView();
        }
    }
}