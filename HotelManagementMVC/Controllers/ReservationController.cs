using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVC.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}