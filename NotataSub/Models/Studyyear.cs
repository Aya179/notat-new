using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Studyyear
    {
        public Studyyear()
        {
            Lectures = new HashSet<Lecture>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Yearname { get; set; } = null!;
        public int? Deptid { get; set; }

        public virtual Department? Dept { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
