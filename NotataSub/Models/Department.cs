using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
            Studyyears = new HashSet<Studyyear>();
        }

        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int UniversityId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Faculty Faculty { get; set; } = null!;
        public virtual University University { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Studyyear> Studyyears { get; set; }
    }
}
