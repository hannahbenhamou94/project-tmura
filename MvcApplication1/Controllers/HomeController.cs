using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

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

        public ActionResult home(String username, int pass)
        {

            ViewBag.result = "ppp";
            MyDataBaseEntities Db = new MyDataBaseEntities();
            List<person> lp = Db.person.ToList();
            /*foreach (  user username in person)
             {
                   
             }*/
           string user = username.ToString();
            string userw = user;
             string passw = pass.ToString();

            foreach (var item in lp)
            {
                string[] ff = item.username.Split(' ');
                string[] hh = item.password.Split(' ');
                if (ff[0] == userw)
                        if (hh[0] == passw)
                {
                    ViewBag.result = "hiii";
                    return View();
                }
            }
                    ViewBag.result = "שם משתמש או סיסמה שגויים";
                return View("index");
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
