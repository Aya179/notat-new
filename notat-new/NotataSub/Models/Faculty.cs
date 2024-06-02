using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Courses = new HashSet<Course>();
            Departments = new HashSet<Department>();
            News = new HashSet<News>();
            Students = new HashSet<Student>();
        }

        public int FacultyId { get; set; }
        public int UniersityId { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual University Uniersity { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
