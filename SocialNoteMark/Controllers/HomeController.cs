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
        public ActionResult Index()
        {
            Bulletin newBulletin = db.Bulletins.SqlQuery("select * from Bulletins where type='0'and flag='0' AND UserName = '" + @User.Identity.Name + "';").ToList()[0];
            List<Bulletin> RecruitList =  db.Bulletins.SqlQuery("select * from Bulletins where type='1' and flag='0'").ToList();
            RecruitList.Reverse();
            List<Note> NoteList = db.Notes.Where(u => u.PermissionType == 0).ToList();
            NoteList.Reverse();
            ViewBag.NoteList = NoteList;
            ViewBag.newBulletin = newBulletin;
            ViewBag.RecruitList = RecruitList;
        var userInfo = db.UserInfoes.First(u => u.UserName == User.Identity.Name);
            ViewBag.ImageUrl = userInfo.ImageUrl;

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