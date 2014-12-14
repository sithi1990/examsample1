using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutorLib.Model;
using PagedList;
using PagedList.Mvc;

namespace TutionWeb1.Controllers
{
    public class ExamController : Controller
    {
        private EducLKDB2Entities1 db = new EducLKDB2Entities1();

        // GET: /Exam/
        public ActionResult Index(int? page)
        {
            var examinations = db.Examinations.Include(e => e.Subject).Include(e => e.Tutor);
            return View(examinations.ToList().ToPagedList(page ?? 1,1));
        }

        // GET: /Exam/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // GET: /Exam/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "FirstName");
            return View();
        }

        // POST: /Exam/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ExamID,ExamName,ExamNote,IsPublished,HasCommonEnroll,EnrollKey,SubjectID,TutorID")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Examinations.Add(examination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examination.SubjectID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "FirstName", examination.TutorID);
            return View(examination);
        }

        // GET: /Exam/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examination.SubjectID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "FirstName", examination.TutorID);
            return View(examination);
        }

        // POST: /Exam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ExamID,ExamName,ExamNote,IsPublished,HasCommonEnroll,EnrollKey,SubjectID,TutorID")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", examination.SubjectID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "FirstName", examination.TutorID);
            return View(examination);
        }

        // GET: /Exam/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = db.Examinations.Find(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        // POST: /Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Examination examination = db.Examinations.Find(id);
            db.Examinations.Remove(examination);
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
