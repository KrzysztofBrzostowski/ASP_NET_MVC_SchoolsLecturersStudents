using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsLecturersStudents.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int LecturerID { get; set; }
        public int StudentID { get; set; }

        //public Grade? Grade { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual Student Student { get; set; }
    }
}