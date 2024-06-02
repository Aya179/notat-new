using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.Models
{
    public partial class Catogary
    {
        public Catogary()
        {
            Books = new HashSet<Book>();
            SubCatogaries = new HashSet<SubCatogary>();
        }

        [Display(Name="المعرف")]
        public int Id { get; set; }

        [Display(Name = "اسم الفئة")]
        public string? Name { get; set; }
        [Display(Name = "الصورة")]
        public byte[]? Image { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<SubCatogary> SubCatogaries { get; set; }
    }
}
