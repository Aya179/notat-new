using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentLecture
    {
        public int SlId { get; set; }
        public int? StudentId { get; set; }
        public int? LectureId { get; set; }
        public DateTime? ViewDate { get; set; }
        public DateTime? DownloadDate { get; set; }
        public bool? IsFav { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Lecture? Lecture { get; set; }
        public virtual Student? Student { get; set; }
    }
}
