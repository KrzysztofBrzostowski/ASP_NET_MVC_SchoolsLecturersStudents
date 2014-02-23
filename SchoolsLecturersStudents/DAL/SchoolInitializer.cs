using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SchoolsLecturersStudents.Models;

namespace SchoolsLecturersStudents.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {

        protected override void Seed(SchoolContext context)
        {
            var schools = new List<School> 
            {
                new School{ ID=1, City="Warszawa", SchoolName="Hose Marti", StreetName="Staffa", Score=5},
                new School{ ID=2, City="Warszawa", SchoolName="C. K. Nowida", StreetName="Jana Pawła", Score=4},
                new School{ ID=3, City="Warszawa", SchoolName="Kasprowicza", StreetName="Inżynierska", Score=7}

            };

            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
            new Student{  FirstName="Marcin",LastName="Madej" , SchoolID=1},
            new Student{  FirstName="Krzysztof",LastName="Brzostowski", SchoolID=1},
            new Student{  FirstName="Marta",LastName="Fedorczyk", SchoolID=1},
            new Student{  FirstName="Rafał",LastName="Komisarz", SchoolID=1},
            new Student{  FirstName="Monika",LastName="Sykus", SchoolID=2},
            new Student{  FirstName="Monika",LastName="Sobczak", SchoolID=2},
            new Student{  FirstName="Maciej",LastName="Stępien", SchoolID=2},
            new Student{  FirstName="Karol",LastName="Kobos", SchoolID=2},
            new Student{  FirstName="Radosław",LastName="Jóżwik", SchoolID=3},
            new Student{  FirstName="Magdalena",LastName="Luniak", SchoolID=3},
            new Student{  FirstName="Jan",LastName="Rambo", SchoolID=3},
            new Student{  FirstName="Marek",LastName="Kurcz", SchoolID=3}

            };

            foreach (var item in students)
            {
                context.Students.Add(item);
            }

            //students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var lecturers = new List<Lecturer> 
            {
                new Lecturer{ ID=1, FirstName="Janusz", LastName="Noniewicz"},
                new Lecturer{ ID=2, FirstName="Leszek", LastName="Zajączkowski"},
                new Lecturer{ ID=3, FirstName="Beata", LastName="Kozidrak"},
                new Lecturer{ ID=4, FirstName="Zbigniew", LastName="Boniek"},
                new Lecturer{ ID=5, FirstName="Janusz", LastName="Panasewicz"},
                new Lecturer{ ID=6, FirstName="Czesław", LastName="Niemen"},
            };

            lecturers.ForEach(s => context.Lecturers.Add(s));
            context.SaveChanges();


            var enrollments = new List<Enrollment> 
            { 
            new Enrollment{ StudentID=1,    LecturerID=1  },
            new Enrollment{ StudentID=1,    LecturerID=6  },

            new Enrollment{ StudentID=2,    LecturerID=2  },
            new Enrollment{ StudentID=2,    LecturerID=3  },

            new Enrollment{ StudentID=3,    LecturerID=1  },
            new Enrollment{ StudentID=3,    LecturerID=5  },

            new Enrollment{ StudentID=4,    LecturerID=2  },
            new Enrollment{ StudentID=4,    LecturerID=4  },

            new Enrollment{ StudentID=5,    LecturerID=1  },

            new Enrollment{ StudentID=6,    LecturerID=2  },
            new Enrollment{ StudentID=6,    LecturerID=4  },

            new Enrollment{ StudentID=7,    LecturerID=3  },
            new Enrollment{ StudentID=7,    LecturerID=6  },

            new Enrollment{ StudentID=8,    LecturerID=1  },
            new Enrollment{ StudentID=8,    LecturerID=3  },

            new Enrollment{ StudentID=9,    LecturerID=2  },
            new Enrollment{ StudentID=9,    LecturerID=6  },

            new Enrollment{ StudentID=10,    LecturerID=2  },
            new Enrollment{ StudentID=10,    LecturerID=3  },

            new Enrollment{ StudentID=11,    LecturerID=3  },

            new Enrollment{ StudentID=12,    LecturerID=3  }

            };

            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            var engagements = new List<Engagement> 
            {
                new Engagement { LecturerID=1,  SchoolID=1  },
                new Engagement { LecturerID=1,  SchoolID=2  },

                new Engagement { LecturerID=2,  SchoolID=1  },
                new Engagement { LecturerID=2,  SchoolID=2  },
                new Engagement { LecturerID=2,  SchoolID=3  },

                new Engagement { LecturerID=3,  SchoolID=1  },
                new Engagement { LecturerID=3,  SchoolID=2  },
                new Engagement { LecturerID=3,  SchoolID=3  },

                new Engagement { LecturerID=4,  SchoolID=1  },
                new Engagement { LecturerID=4,  SchoolID=2  },

                new Engagement { LecturerID=5,  SchoolID=1  },
                new Engagement { LecturerID=5,  SchoolID=3  },

                new Engagement { LecturerID=6,  SchoolID=1  },
                new Engagement { LecturerID=6,  SchoolID=2  },
                new Engagement { LecturerID=6,  SchoolID=3  }
            };

            engagements.ForEach(s => context.Engagements.Add(s));
            context.SaveChanges();

        }
    }
}
