using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Writer
    {
        public Writer()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Information { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
