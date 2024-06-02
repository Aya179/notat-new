using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class OnlineLecture
    {
        public OnlineLecture()
        {
            StudentPresenses = new HashSet<StudentPresense>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? LectureNum { get; set; }
        public DateTime? Publishdate { get; set; }
        public string? Description { get; set; }
        public string? Files { get; set; }
        public int? CourseId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnLineCourse? Course { get; set; }
        public virtual ICollection<StudentPresense> StudentPresenses { get; set; }
    }
}
