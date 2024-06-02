using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class RegisterationType
    {
        public RegisterationType()
        {
            StudentRegisters = new HashSet<StudentRegister>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;
        public int? Duration { get; set; }
        public decimal Price { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StudentRegister> StudentRegisters { get; set; }
    }
}
