using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNoteMark.Models;
using Microsoft.AspNet.Identity;

namespace SocialNoteMark.Controllers
{
    [Authorize()]
    public class FriendController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.Create();

        // GET: Friend
        public ActionResult Index()
        {
            List<FriendRelation> friendList = db.FriendRelations.Where(u => u.FromName == User.Identity.Name).ToList();
            var nameList = new List<String>();
            var imageUrlList = new List<String>();
            foreach (var fd in friendList)
            {
                var friendName = fd.ToName;
                var userInfo = db.UserInfoes.FirstOrDefault(u => u.UserName == friendName);
                nameList.Add(friendName);
                imageUrlList.Add(userInfo.ImageUrl);
            }
            ViewBag.NameList = nameList;
            ViewBag.ImageUrlList = imageUrlList;
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            String fromName = User.Identity.Name;
            String toName = Request.Params["toName"];
            db.FriendRelations.Add(new FriendRelation { FromName = fromName, ToName = toName });
            db.FriendRelations.Add(new FriendRelation { FromName = toName, ToName = fromName });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}