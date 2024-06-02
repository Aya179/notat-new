using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class RegisterOnLine
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime? Registerdate { get; set; }
        public int? Reviews { get; set; }
        public int? CurrentLesson { get; set; }
        public bool? IsDone { get; set; }
        public bool? IsPassed { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnLineCourse Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
