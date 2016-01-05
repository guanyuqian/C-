using SocialNoteMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNoteMark.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<Bulletin> BulletinList;
        public ActionResult Index()
        {
            //BulletinList = db.Bulletins.SqlQuery("select * from Bulletins where type='0'and flag='0'").ToList();
            //BulletinList.Reverse();
            //ViewData["BulletinList"] = BulletinList;
            return View();
 
        }
  
   
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}