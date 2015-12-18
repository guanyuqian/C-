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
            return View(db.Notes.ToList());
        }


        public ActionResult Create()
        {
            return View();
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
            if (tagStr == null) return;
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