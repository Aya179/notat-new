using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Hashtag
    {
        public Hashtag()
        {
            CourseHashtags = new HashSet<CourseHashtag>();
        }

        public int Id { get; set; }
        public string? HashtagText { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<CourseHashtag> CourseHashtags { get; set; }
    }
}
