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
    public class NoteController : Controller
    {
        private ApplicationDbContext db = ApplicationDbContext.Create();
        // GET: Note
        public ActionResult Index()
        {
            var UserName = User.Identity.Name; 
            ViewBag.publicList = db.Notes.Where(u => u.UserName == UserName).Where(u => u.PermissionType == 0).ToList();
            ViewBag.friendlyList = db.Notes.Where(u => u.UserName == UserName).Where(u => u.PermissionType == 1).ToList();
            ViewBag.privateList = db.Notes.Where(u => u.UserName == UserName).Where(u => u.PermissionType == 2).ToList();

            var userInfo = db.UserInfoes.First(u => u.UserName == User.Identity.Name);
            ViewBag.ImageUrl = userInfo.ImageUrl;

            return View(db.Notes.ToList());
        }

        public ActionResult History()
        {
            var UserName = User.Identity.Name;
            ViewBag.noteList = db.Notes.Where(u => u.UserName == UserName).OrderByDescending(u => u.CreatTime).ToList();
            return View(db.Notes.Where(u => u.UserName == UserName).OrderByDescending(u => u.CreatTime).ToList());
        }

        [Route("[action]/{id:int}")]
        public ActionResult show(int id)
        {
            var note = db.Notes.Find(id);
            ViewBag.Note = note;
            var user = db.Users.First(u =>u.UserName == note.UserName);
            ViewBag.User = user;
            ViewBag.NoteList = db.Notes.Where(u => u.UserName == note.UserName).Where(u => u.NoteID != id).ToList();
            var userInfo = db.UserInfoes.First(u => u.UserName == User.Identity.Name);
            ViewBag.ImageUrl = userInfo.ImageUrl;
            List<FriendRelation> fdList = db.FriendRelations.Where(u => u.FromName == User.Identity.Name).Where(u => u.ToName == note.UserName).ToList();
            String RelationStatus = "";
            if (fdList.Count != 0)
            {
                RelationStatus = "Friend";
            }
            else if (note.UserName == User.Identity.Name)
            {
                RelationStatus = "Self";
            }
            else
            {
                RelationStatus = "Stranger";
            }
            ViewBag.FriendRelation = RelationStatus;
            return View();
        }

        [Route("[action]/{id:int}")]
        public ActionResult delete(int id)
        {
            Note note = db.Notes.Find(id);
            if (note != null)
            {
                db.Notes.Remove(note);
                db.SaveChanges();
            }    
            return RedirectToAction("Index");
        }

        [Route("[action]/{id:int}")]
        public ActionResult Edit(int id)
        {
            Note note = db.Notes.Find(id);
            if (note != null)
            {
                ViewBag.Note = note;
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "NoteID,Title,Description,Content,PermissionType")] Note note)
        {
            Note n = db.Notes.Find(note.NoteID);
            n.Content = note.Content;
            n.Description = note.Description;
            n.PermissionType = note.PermissionType;
            n.EditTime = DateTime.Now;

            String tagStr = Request.Form["tag"];
            addTag(note.NoteID, tagStr);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "NoteID,Title,Description,Content,PermissionType")] Note note)
        {
            note.UserName = User.Identity.Name;
            note.CreatTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                note = db.Notes.Add(note);
                db.SaveChanges();

                String tagStr = Request.Form["tag"];
                addTag(note.NoteID, tagStr);
                return RedirectToAction("Index");
            }

            return View(note);
        }

        private void addTag(int noteId, String tagStr)
        {
            if (tagStr == null || tagStr == "") return;
            String[] tags = tagStr.Substring(0,tagStr.Length-1).Split('/');
            foreach (String name in tags) 
            {
                if (db.Tags.Count(u => u.Name == name) == 0)
                {
                    db.Tags.Add(new Tag() { Name = name });
                    db.SaveChanges();
                }
                Tag tag = db.Tags.First(u => u.Name == name);
                NoteTagLog log = new NoteTagLog() { NoteID = noteId, TagID = tag.TagID};
                db.NoteTagLogs.Add(log);
                db.SaveChanges();
            }
        }
    }
}