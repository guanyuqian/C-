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
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }
    }
}