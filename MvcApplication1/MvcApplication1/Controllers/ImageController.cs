using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.SqlClient;
using System.Data.EntityModel;

namespace MvcApplication1.Controllers
{

    public class ImageController : Controller
    {
        //
        // GET: /Image/

        // public string connectionString = "Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True";

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult galery()
        {
            //MyDataBaseEntities Db2 = new MyDataBaseEntities();
            //List<Image> all = Db2.Image.ToList();
            // var j = "ggg";
            //j.b
            //Image w = new Image() { ImageId = 77, Imagesize = 5, FileName = "wor", ImageData = j };
            List<Image> all = new List<Image>();
            using (MyDataBaseEntities dg = new MyDataBaseEntities())

                all = dg.Image.ToList();

            return View(all);
        }

        public ActionResult Upload()
        {
            return View("Upload");
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
                DateTime datetoday = DateTime.Now;
                // worksuggests f = new worksuggests() { fileID = 59, fileName="jjj" , content = "gvbhnjmk,l", filedate = datetoday };
                // dc.worksuggests.Add(f);

                //Image w = new Image() { ImageId = IG.ImageId, Imagesize = IG.Imagesize, FileName =IG.FileName, ImageData = IG.ImageData };
                dc.Image.Add(IG);
                dc.SaveChanges();
            }
            return RedirectToAction("galery");

        }

    }
}
