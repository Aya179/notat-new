using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentRegisterOnline
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? Date { get; set; }
        public int? CobonId { get; set; }
        public int? Review { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnlineCobon? Cobon { get; set; }
        public virtual OnLineCourse? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
