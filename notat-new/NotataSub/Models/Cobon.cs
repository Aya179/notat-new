using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Cobon
    {
        public Cobon()
        {
            StudentRegisters = new HashSet<StudentRegister>();
        }

        public int CobonId { get; set; }
        public decimal CobonValue { get; set; }
        public string CobonNumber { get; set; } = null!;
        public bool IsValid { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StudentRegister> StudentRegisters { get; set; }
    }
}
