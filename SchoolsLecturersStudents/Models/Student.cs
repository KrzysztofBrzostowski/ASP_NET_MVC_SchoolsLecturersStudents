using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsLecturersStudents.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        //        public DateTime EnrollmentDate { get; set; }

        //[Display(Name = "School")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}