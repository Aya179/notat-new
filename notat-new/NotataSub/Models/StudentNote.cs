using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentNote
    {
        public int NoteId { get; set; }
        public int? StudentId { get; set; }
        public string? NoteText { get; set; }
        public int? LectureId { get; set; }
        public int? Page { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual Student? Student { get; set; }
    }
}
