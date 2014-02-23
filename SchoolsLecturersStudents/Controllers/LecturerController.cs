using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolsLecturersStudents.DAL;
using SchoolsLecturersStudents.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Net;


namespace SchoolsLecturersStudents.Controllers
{
    public class LecturerController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Lecturer/
        public ActionResult Index()
        {
            return View(db.Lecturers.ToList());
        }

        //OK
        // GET: /Lecturer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }

            return View(lecturer);
        }

        //OK
        // GET: /Lecturer/Create
        public ActionResult Create()
        {
            return View();
        }


        //OK
        // POST: /Lecturer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "LastName, FirstName")]Lecturer lecturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Lecturers.Add(lecturer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(lecturer);
        }

        //OK
        // GET: /Lecturer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        //OK
        // POST: /Lecturer/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, LastName, FirstName")]Lecturer lecturer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(lecturer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(lecturer);
        }

        //
        // GET: /Lecturer/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);

        }

        //
        // POST: /Lecturer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Lecturer lecturer = db.Lecturers.Find(id);
                db.Lecturers.Remove(lecturer);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
