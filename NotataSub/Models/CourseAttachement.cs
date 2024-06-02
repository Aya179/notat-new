using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class CourseAttachement
    {
        public int AttachementId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Description { get; set; }
        public string? AttachUrl { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Course? Course { get; set; }
    }
}
