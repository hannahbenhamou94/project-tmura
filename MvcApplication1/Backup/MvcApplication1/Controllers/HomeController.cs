using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult home()
        {
            return View();
        }
        public ActionResult lessons()
        {
            return View ();
        }
        public ActionResult galery()
        {
            string year = Convert.ToString(Request["id"]);
            ViewBag.year = year;
            return View();
        }
        public ActionResult galery2()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult recipe()
        {
            return View();
        }
        public ActionResult site()
        {
            return View();
        }
        public ActionResult worksite()
        {
            return View();
        }   
        public ActionResult expert()
        {
            return View();
        }
        public ActionResult workssuggest()
        {
            return View();
        }
        
    }
    
}
