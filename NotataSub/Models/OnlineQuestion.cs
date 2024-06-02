using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class OnlineQuestion
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public string? Ans1 { get; set; }
        public string? Ans2 { get; set; }
        public string? Ans3 { get; set; }
        public string? Ans4 { get; set; }
        public string? Ans5 { get; set; }
        public int Answer { get; set; }
    }
}
