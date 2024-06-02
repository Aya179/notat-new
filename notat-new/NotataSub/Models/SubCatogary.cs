using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.Models
{
    public partial class SubCatogary
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "الفئة")]
        public int? CatogaryId { get; set; }
        [Display(Name = "الاسم")]
        public string? Name { get; set; }

        public virtual Catogary? Catogary { get; set; }
    }
}
