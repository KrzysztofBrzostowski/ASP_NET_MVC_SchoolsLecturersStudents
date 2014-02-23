using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolsLecturersStudents.DAL;
using SchoolsLecturersStudents.Models;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Data.Entity;


namespace SchoolsLecturersStudents.Controllers
{
    public class SchoolController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //OK
        // GET: /School/
        public ActionResult Index()
        {
            return View(db.Schools.ToList());
        }

        //OK
        // GET: /School/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }

            return View(school);

        }

        //OK
        // GET: /School/Create
        public ActionResult Create()
        {
            return View();
        }


        //OK
        // POST: /School/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "StreetName, SchoolName, City, Score")]School school)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Schools.Add(school);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(school);
        }

        //OK
        // GET: /School/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        //OK
        // POST: /School/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, StreetName, SchoolName, City, Score")]School school)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(school).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(school);
        }

        //OK
        // GET: /School/Delete/5
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
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);

        }

        //
        // POST: /School/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                School school = db.Schools.Find(id);
                db.Schools.Remove(school);
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
