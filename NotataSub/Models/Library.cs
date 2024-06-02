using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Library
    {
        public int LibId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
