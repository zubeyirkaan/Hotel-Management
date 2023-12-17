using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HotelManagementMVC.Models.Entity;

namespace HotelManagementMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        DbHotelEntities db = new DbHotelEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblNewRegistry p)
        {
            var datas = db.TblNewRegistries.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if(datas!=null)
            {
                FormsAuthentication.SetAuthCookie(datas.Email,false);
                Session["Email"] = datas.Email.ToString();
                return RedirectToAction("Index","Guest");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}