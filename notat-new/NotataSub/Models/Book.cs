using System;
using System.Collections.Generic;

namespace NotataSub.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public int? CatId { get; set; }
        public int? WritreId { get; set; }
        public string? Title { get; set; }
        public int? Pages { get; set; }
        public int? Price { get; set; }
        public DateTime? Year { get; set; }
        public string? IsDeleted { get; set; }

        public virtual Catogary? Cat { get; set; }
        public virtual Writer? Writre { get; set; }
    }
}
