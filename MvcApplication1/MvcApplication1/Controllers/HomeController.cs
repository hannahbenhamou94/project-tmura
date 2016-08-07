using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.SqlClient;

//using Systems.Net.Mail;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {

        public string connectionString = "Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True";
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
       /* public ActionResult galery()
        {
            string year = Convert.ToString(Request["id"]);
            ViewBag.year = year;
            return View();
        }*/
        public ActionResult galery2()
        {
            return View();
        }
        public ActionResult test()
        {

            return View();
        }

        public ActionResult back()
        {
            return View("home");
        }

        public ActionResult home(String username, int pass)
        {

            ViewBag.result = "ppp";
            MyDataBaseEntities1 Db = new MyDataBaseEntities1();
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
                    ViewBag.result = username;
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
        public ActionResult workssuggest2(String name, String worksugg)
        {
            MyDataBaseEntities1 Db1 = new MyDataBaseEntities1();
            List<worksuggests> lp1 = Db1.worksuggests.ToList();

            int hid = lp1[lp1.Count - 1].fileID;
            hid++;
            MyDataBaseEntities1 DB = new MyDataBaseEntities1();
            string name3 = name.ToString();
            string wor = worksugg.ToString();
            DateTime datetoday = DateTime.Now;
            worksuggests w = new worksuggests() { fileID = hid, fileName = name3, content = wor, filedate = datetoday };
            //temp = temp + 1;
           // ViewBag.idworksuggest = temp;
            DB.worksuggests.Add(w);
            DB.SaveChanges();
            MyDataBaseEntities1 Db = new MyDataBaseEntities1();
            List<worksuggests> lp = Db.worksuggests.ToList();
            return View(lp);

        }

        public ActionResult work()
        {
            MyDataBaseEntities1 Db = new MyDataBaseEntities1();
            List<worksuggests> lp = Db.worksuggests.ToList();

            return View("workssuggest2",lp);
        }

        public ActionResult workssuggest3()
        {
            return View();
        }
        public ActionResult workssuggest()
        {

          /*  using(SqlConnection connection = new SqlConnection(connectionString))
                
            using (SqlCommand command = new SqlCommand("",connection))
            {
             
               command.CommandText = "insert into worksuggest values(2,'adar','bhbkjnk','1232')";
                //command.Parameters.AddWithValue("jjj", worksuggest);
               connection.Open();
               command.ExecuteNonQuery();
            }*/
            return View();
        }
        public ActionResult Email()
        {
            MyDataBaseEntities1 conn = new MyDataBaseEntities1();
            List<person> lp = conn.person.ToList();
            foreach (var item in lp)
            {
                String[] ff = item.username.Split(' ');
                String User = ViewBag.result;
              
                if (ff[0] == (User))
                    {
                        String mail = item.email;
                        //Mail email = new Mail();





                        return View();
                    }
            }

                return View();



        }
    //    public class ImageGalleryController : Controller
       // {

            public ActionResult galery()
            {
                MyDataBaseEntities Db2 = new MyDataBaseEntities();
                List<Image> all = Db2.Image.ToList();
               /* List<Image> all = new List<Image>();
                 using (MyDataBaseEntities dg = new MyDataBaseEntities())

                 all = dg.Image.ToList();*/

                return View(all);
            }
            public ActionResult upload()
            {
                return View();
            }
            
        [HttpPost]
              public ActionResult Upload(Image IG)
            {
                // Apply Validation Here


                if (IG.File.ContentLength > (2 * 1024 * 1024))
                {
                    ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                    return View();
                }
                if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
                {
                    ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                    return View();
                }

                IG.FileName = IG.File.FileName;
                IG.Imagesize = IG.File.ContentLength;

                byte[] data = new byte[IG.File.ContentLength];
                IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

                IG.ImageData = data;
                using (MyDataBaseEntities dc = new MyDataBaseEntities())
              
                {
                    dc.Image.Add(IG);
                    dc.SaveChanges();
                }
                return RedirectToAction("galery");

            }
        




      //  }
        /*[HttpPost]
        public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }*/



    }
    
}
