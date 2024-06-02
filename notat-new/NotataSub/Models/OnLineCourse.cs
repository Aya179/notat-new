using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class OnLineCourse
    {
        public OnLineCourse()
        {
            CourseHashtags = new HashSet<CourseHashtag>();
            CourseOffers = new HashSet<CourseOffer>();
            OnlineExams = new HashSet<OnlineExam>();
            OnlineLectures = new HashSet<OnlineLecture>();
            RegisterOnLines = new HashSet<RegisterOnLine>();
            StudentRegisterOnlines = new HashSet<StudentRegisterOnline>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public bool? IsUniversity { get; set; }
        public decimal? Cost { get; set; }
        public int? NumOfLectures { get; set; }
        public string? Description { get; set; }
        public string? Teacher { get; set; }
        public string? Domain { get; set; }
        public string? PromoLink { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<CourseHashtag> CourseHashtags { get; set; }
        public virtual ICollection<CourseOffer> CourseOffers { get; set; }
        public virtual ICollection<OnlineExam> OnlineExams { get; set; }
        public virtual ICollection<OnlineLecture> OnlineLectures { get; set; }
        public virtual ICollection<RegisterOnLine> RegisterOnLines { get; set; }
        public virtual ICollection<StudentRegisterOnline> StudentRegisterOnlines { get; set; }
    }
}
