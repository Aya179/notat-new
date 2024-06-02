using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class CourseExam
    {
        public CourseExam()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
        }

        public int ExamId { get; set; }
        public int? CourseId { get; set; }
        public int? Passes { get; set; }
        public int? Failed { get; set; }
        public DateTime? ExamDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
