using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NotataSub.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseAttachements = new HashSet<CourseAttachement>();
            CourseExams = new HashSet<CourseExam>();
            Lectures = new HashSet<Lecture>();
            StudentCourses = new HashSet<StudentCourse>();
        }
      

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int FacultyId { get; set; }
        public string Teacher { get; set; } = null!;
        public int Year { get; set; }
        public int Semester { get; set; }
        public int DepartmentId { get; set; }
        public bool? IsDeleted { get; set; }
        public int Price { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Faculty Faculty { get; set; } = null!;
        public virtual ICollection<CourseAttachement> CourseAttachements { get; set; }
        public virtual ICollection<CourseExam> CourseExams { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
