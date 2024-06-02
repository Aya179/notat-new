using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Photo { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
