using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class OnlineCobon
    {
        public OnlineCobon()
        {
            StudentRegisterOnlines = new HashSet<StudentRegisterOnline>();
        }

        public int Id { get; set; }
        public decimal? Value { get; set; }
        public int? Number { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? LibId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPayes { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StudentRegisterOnline> StudentRegisterOnlines { get; set; }
    }
}
