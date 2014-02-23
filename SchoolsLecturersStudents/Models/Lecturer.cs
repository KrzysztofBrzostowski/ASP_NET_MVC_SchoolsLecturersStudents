using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsLecturersStudents.Models
{
    public class Lecturer
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }


    }
}