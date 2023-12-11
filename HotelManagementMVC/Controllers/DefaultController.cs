using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
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