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
            var nameList = new List<String>();
            var imageUrlList = new List<String>();
            var requestList = new List<FriendRequest>();
            var noteList = new List<Note>();

            List<FriendRelation> friendList = db.FriendRelations.Where(u => u.FromName == User.Identity.Name).ToList();
            foreach (var fd in friendList)
            {
                var friendName = fd.ToName;
                var userInfo = db.UserInfoes.FirstOrDefault(u => u.UserName == friendName);
                nameList.Add(friendName);
                imageUrlList.Add(userInfo.ImageUrl);

                List<Note> friendNoteList = db.Notes.Where(u => u.UserName == friendName).ToList();
                foreach (var note in friendNoteList)
                    noteList.Add(note);
            }
            requestList = db.FriendRequests.Where(u => u.ToName == User.Identity.Name).ToList();

            ViewBag.NameList = nameList;
            ViewBag.ImageUrlList = imageUrlList;
            ViewBag.RequestList = requestList;
            ViewBag.noteList = noteList;
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

        [HttpPost]
        public ActionResult CreateRequest()
        {
            String fromName = User.Identity.Name;
            String toName = Request.Params["toName"];
            if(toName != null && toName != ""){
                db.FriendRequests.Add(new FriendRequest { FromName = fromName, ToName = toName });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AcceptRequest()
        {
            int requestId = Convert.ToInt32(Request.Params["id"]);
            FriendRequest fq = db.FriendRequests.Find(requestId);

            String fromName = fq.FromName;
            String toName = fq.ToName;
            db.FriendRelations.Add(new FriendRelation { FromName = fromName, ToName = toName });
            db.FriendRelations.Add(new FriendRelation { FromName = toName, ToName = fromName });
            db.FriendRequests.Remove(fq);
            db.SaveChanges();
            return null;
        }

        [HttpPost]
        public ActionResult RejectRequest()
        {
            int requestId = Convert.ToInt32(Request.Params["id"]);
            FriendRequest fq = db.FriendRequests.Find(requestId);
            db.FriendRequests.Remove(fq);
            db.SaveChanges();
            return null;
        }
    }
}