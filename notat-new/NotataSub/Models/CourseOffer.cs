using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class CourseOffer
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? OfferId { get; set; }

        public virtual OnLineCourse? Course { get; set; }
        public virtual Offer? Offer { get; set; }
    }
}
