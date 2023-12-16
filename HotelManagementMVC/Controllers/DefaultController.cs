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
            return PartialView();
        }

        public PartialViewResult PartialSocialMedia()
        {
            return PartialView();
        }
    }
}