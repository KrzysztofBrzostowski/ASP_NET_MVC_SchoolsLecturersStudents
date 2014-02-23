using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsLecturersStudents.Models
{
    public class Engagement
    {
        public int EngagementID { get; set; }

        public int SchoolID { get; set; }
        public int LecturerID { get; set; }

        public virtual School School { get; set; }
        public virtual Lecturer Lecturer { get; set; }

    }
}