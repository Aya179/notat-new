using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentExamOnLine
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? ExamId { get; set; }
        public DateTime? ExamDate { get; set; }
        public int? Mark { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnlineExam? Exam { get; set; }
        public virtual Student? Student { get; set; }
    }
}
