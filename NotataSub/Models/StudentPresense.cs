using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentPresense
    {
        public int Id { get; set; }
        public DateTime? PresenseDate { get; set; }
        public int? StudentId { get; set; }
        public int? LectureId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnlineLecture? Lecture { get; set; }
        public virtual Student? Student { get; set; }
    }
}
