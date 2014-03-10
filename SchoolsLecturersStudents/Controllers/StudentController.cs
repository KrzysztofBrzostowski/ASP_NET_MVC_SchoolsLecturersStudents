using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolsLecturersStudents.DAL;
using SchoolsLecturersStudents.Models;


namespace SchoolsLecturersStudents.Controllers
{
    public class StudentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {

            IEnumerable<SelectListItem> userTypeList = new SelectList(db.Schools.ToList(), "ID", "SchoolName");
            ViewData["User_School_Type"] = userTypeList;


            return View();
        }


        // bez "EnrollmentDate"
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, LastName, FirstName, SchoolID")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SelectListItem> userTypeList = new SelectList(db.Schools.ToList(), "ID", "SchoolName");
            ViewData["User_School_Type"] = userTypeList;

            //lecturers podpieci do KB
            var ids = db.Enrollments.Where(e => e.StudentID == id.Value).Select(e => e.LecturerID).ToList();

            //do listy rozwijaklnej tylko ci co nie sa podpieci do KB
            var Lecturers0 = db.Lecturers.Where(l => !ids.Contains(l.ID));
            ViewBag.Lectures2 = Lecturers0.ToList();

            //IEnumerable<SelectListItem> userTypeList2 = new SelectList(Lecturers0.ToList(), "ID", "LastName");
            //ViewData["User_Lecturer_Type"] = userTypeList2;

            return View(student);
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID, LastName, FirstName, SchoolID")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }


        //najpierw dodajemy do bazy danych, wtedy dostajemy komunmkat: "udalo sie lub nie udalo sie"
        [HttpPost]
        public ActionResult AddLectureToStudent(int? lectureID, int? studentID)
        {
            db.Enrollments.Add(new Enrollment { LecturerID = lectureID.Value, StudentID = studentID.Value });

            return Content((db.SaveChanges() == 1).ToString());
        }



        //
        // GET: /Student/Delete/5
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
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }



        //DeleteEnrollment
        [HttpGet]
        public ActionResult DeleteEnrollmentConfirm(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            var enrollemt = db.Enrollments.SingleOrDefault(m => m.EnrollmentID == id);
            if (enrollemt == null)
            {
                return HttpNotFound();
            }
            return View(enrollemt);



        }


        [HttpPost]
        public ActionResult DeleteEnrollment([Bind(Include = "EnrollmentID")]Enrollment Enr)
        {
            int studentID = 0;

            try
            {

                var enrollemt = db.Enrollments.SingleOrDefault(m => m.EnrollmentID == Enr.EnrollmentID);

                if (enrollemt == null)
                {
                    return HttpNotFound();
                }

                studentID = enrollemt.StudentID;
                //if (enrollemt == null)  {  return HttpNotFound();    }
                //Student student = db.Students.Find(id);
                db.Enrollments.Remove(enrollemt);
                db.SaveChanges();
            }
            catch (RetryLimitExceededException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("DeleteEnrollment", new { id = Enr.EnrollmentID });
            }
            return RedirectToAction("Edit", new { id = studentID });
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
