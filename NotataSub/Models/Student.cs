using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Student
    {
        public Student()
        {
            RegisterOnLines = new HashSet<RegisterOnLine>();
            StudentCourses = new HashSet<StudentCourse>();
            StudentExamOnLines = new HashSet<StudentExamOnLine>();
            StudentLectures = new HashSet<StudentLecture>();
            StudentNotes = new HashSet<StudentNote>();
            StudentPresenses = new HashSet<StudentPresense>();
            StudentRegisterOnlines = new HashSet<StudentRegisterOnline>();
            StudentRegisters = new HashSet<StudentRegister>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string? Password { get; set; }
        public int FaculityId { get; set; }
        public int DepartmentId { get; set; }
        public bool? IsDeleted { get; set; }
        public int Yearid { get; set; }
        public string? Activationcode { get; set; }
        public bool? Isactive { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Faculty Faculity { get; set; } = null!;
        public virtual Studyyear Year { get; set; } = null!;
        public virtual ICollection<RegisterOnLine> RegisterOnLines { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentExamOnLine> StudentExamOnLines { get; set; }
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
        public virtual ICollection<StudentNote> StudentNotes { get; set; }
        public virtual ICollection<StudentPresense> StudentPresenses { get; set; }
        public virtual ICollection<StudentRegisterOnline> StudentRegisterOnlines { get; set; }
        public virtual ICollection<StudentRegister> StudentRegisters { get; set; }
    }
}
