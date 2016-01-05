using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialNoteMark.Models;

namespace SocialNoteMark.Controllers
{
    public class BulletinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private List<Bulletin> result;

        // GET: Bulletins
        public ActionResult Index()
        {
            result = db.Bulletins.SqlQuery("select * from Bulletins where type='0'and flag='0'").ToList();
            result.Reverse();
            return View(result);
        }
        public ActionResult Manage()
        {
            result = db.Bulletins.SqlQuery("select * from Bulletins where type='0'and flag='0'").ToList();
            result.Reverse();
            return View(result);
        }

        // GET: Bulletins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }

        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }
        // GET: Bulletins/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Bulletins/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BulletionID,UserName,Type,Flag,Name,Content,CreateDate")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                bulletin.UserName = @User.Identity.Name;
                bulletin.Flag = 0;
                bulletin.Type =0;
                bulletin.CreateDate = DateTime.Now;
                Console.WriteLine (Session["userName"]);
               //bulletin.UserName=Session.GetEnumerator
                db.Bulletins.Add(bulletin);
                db.SaveChanges();
                return RedirectToAction(Request.Form["nextPage"]);
            }

            return View(bulletin);
        }

        // GET: Bulletins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }

        // POST: Bulletins/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BulletionID,UserName,Type,Flag,Name,Content,CreateDate")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bulletin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bulletin);
        }

        // GET: Bulletins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bulletin bulletin = db.Bulletins.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            return View(bulletin);
        }

        // POST: Bulletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bulletin bulletin = db.Bulletins.Find(id);
            db.Bulletins.Remove(bulletin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
