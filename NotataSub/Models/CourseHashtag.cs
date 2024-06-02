using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class CourseHashtag
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? HashtagId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual OnLineCourse? Course { get; set; }
        public virtual Hashtag? Hashtag { get; set; }
    }
}
