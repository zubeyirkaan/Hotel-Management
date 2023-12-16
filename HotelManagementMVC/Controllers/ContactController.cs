﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagementMVC.Models.Entity;

namespace HotelManagementMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        DbHotelEntities db = new DbHotelEntities();
        public ActionResult Index()
        {
            var datas = db.TblContacts.ToList();
            return View(datas);
        }
    }
}