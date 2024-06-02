using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Offer
    {
        public Offer()
        {
            CourseOffers = new HashSet<CourseOffer>();
        }

        public int Id { get; set; }
        public string? OfferText { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? Discount { get; set; }
        public string? Discription { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<CourseOffer> CourseOffers { get; set; }
    }
}
