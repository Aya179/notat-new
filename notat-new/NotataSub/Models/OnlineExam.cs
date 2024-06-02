using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class OnlineExam
    {
        public OnlineExam()
        {
            StudentExamOnLines = new HashSet<StudentExamOnLine>();
        }

        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? Passed { get; set; }
        public int? Failed { get; set; }
        public int? NumOfQuestions { get; set; }
        public int? Duration { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnLineCourse? Course { get; set; }
        public virtual ICollection<StudentExamOnLine> StudentExamOnLines { get; set; }
    }
}
