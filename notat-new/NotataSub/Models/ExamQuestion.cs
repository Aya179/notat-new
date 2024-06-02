using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class ExamQuestion
    {
        public int QuestionId { get; set; }
        public int? ExamId { get; set; }
        public string? Question { get; set; }
        public string? Ans1 { get; set; }
        public string? Ans2 { get; set; }
        public string? Ans3 { get; set; }
        public string? Ans4 { get; set; }
        public int? RightAnswer { get; set; }
        public string? Ans5 { get; set; }

        public virtual CourseExam? Exam { get; set; }
    }
}
