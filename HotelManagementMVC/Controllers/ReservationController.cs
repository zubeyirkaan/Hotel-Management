﻿using HotelManagementMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagementMVC.Controllers
{
    public class ReservationController : Controller
    {

        DbHotelEntities db = new DbHotelEntities();
        // GET: Reservation
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblPreReservation p)
        {
            var guestemail = (string)Session["Email"];
            //var guestid = db.TblNewRegistries.Where(x => x.Email == guestemail).Select(x => x.ID).FirstOrDefault();

            //p.Status = 12;
            // p.Guest = guestid;
            p.Email = guestemail;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblPreReservations.Add(p);
            db.SaveChanges();
            return RedirectToAction("Reservations","Guest");
        }
    }
}