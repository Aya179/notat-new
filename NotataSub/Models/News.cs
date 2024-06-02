using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class News
    {
        public int NewsId { get; set; }
        public string? NewsText { get; set; }
        public string? NewsUrl { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? FacultyId { get; set; }

        public virtual Faculty? Faculty { get; set; }
    }
}
