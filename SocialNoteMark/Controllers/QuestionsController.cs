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
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questions
        public ActionResult Index()
        {
            ViewBag.IdentityName = User.Identity.Name;
            return View(db.Questions.Where(
                u=>u.CreateTime.Month == DateTime.Now.Month && u.CreateTime.Day - DateTime.Now.Day < 3).ToList());//显示最近三天的问题
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResult([Bind(Include = "keyWord")] string keyWord)
        {
            if (keyWord == "")
                return RedirectToAction("Search");
            return View(db.Questions.Where(u => u.Title.Contains(keyWord) || u.QuestionDescription.Contains(keyWord)).ToList());
        }

        public ActionResult AnswerThisQuestion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        [HttpPost]
        public ActionResult AnswerResult([Bind(Include = "answerContent,QuestionID")] string answerContent, int questionID)
        {
            if(User.Identity.Name == "")
            {
                return RedirectToAction("Login","Account",null);
            }
            if (db.Questions.Find(questionID) == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (answerContent == "")
                return RedirectToAction("AnswerThisQuestion", "Questions", questionID);
            Answer answer = new Answer();
            answer.AnswererName = User.Identity.Name;
            answer.AnswerContent = answerContent;
            answer.AnswerTime = DateTime.Now;
            answer.QuestionID = questionID;
            db.Answers.Add(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            List<Answer> answers = db.Answers.Where(u => u.QuestionID == id).ToList();
            ViewBag.answers = answers;
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionID,Title,QuestionDescription,QuestionerName,CreatTiem")] Question question)
        {
            if (User.Identity.Name == "")
                return RedirectToAction("Login","Account");
            question.CreateTime = DateTime.Now;
            question.QuestionerName = User.Identity.Name;
            if (question.Title != "")
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,Title,QuestionDescription,QuestionerName,CreatTiem")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
