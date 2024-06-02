using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            StudentLectures = new HashSet<StudentLecture>();
            StudentNotes = new HashSet<StudentNote>();
        }

        public int LectureId { get; set; }
        public int LectureNum { get; set; }
        public string Title { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public int CourseId { get; set; }
        public int Pages { get; set; }
        public bool? IsDeleted { get; set; }
        public int Price { get; set; }
        public int Yearid { get; set; }
        public string Linkurl { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
        public virtual Studyyear Year { get; set; } = null!;
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
        public virtual ICollection<StudentNote> StudentNotes { get; set; }
    }
}
