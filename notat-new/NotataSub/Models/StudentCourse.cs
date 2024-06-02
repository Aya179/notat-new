using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentCourse
    {
        public int ScId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
