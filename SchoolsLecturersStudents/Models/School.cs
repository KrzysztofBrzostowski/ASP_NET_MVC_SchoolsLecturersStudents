using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsLecturersStudents.Models
{
    public class School
    {
        public int ID { get; set; }
        public string StreetName { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }

        public int? Score { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Engagement> Engagements { get; set; }
    }
}