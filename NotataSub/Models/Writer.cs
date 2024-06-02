using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.Models
{
    public partial class Writer
    {
        //public Writer()
        //{
        //    Books = new HashSet<Book>();
        //}
        [Display(Name="المعرف")]
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        public string? Name { get; set; }
        [Display(Name = "معلومات ")]
        public string? Information { get; set; }
        [Display(Name = "الصورة")]
        public byte[]? Image { get; set; }

      
    }
}
