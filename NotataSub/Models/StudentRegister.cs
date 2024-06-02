using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class StudentRegister
    {
        public int SrId { get; set; }
        public int? StudentId { get; set; }
        public int? TypeId { get; set; }
        public int? CobonId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public bool? IsValid { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Cobon? Cobon { get; set; }
        public virtual Student? Student { get; set; }
        public virtual RegisterationType? Type { get; set; }
    }
}
