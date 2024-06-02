using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class University
    {
        public University()
        {
            Departments = new HashSet<Department>();
            Faculties = new HashSet<Faculty>();
        }

        public int UniversityId { get; set; }
        public string UniversityName { get; set; } = null!;
        public string City { get; set; } = null!;
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
