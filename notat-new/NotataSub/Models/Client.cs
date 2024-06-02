using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.Models
{
    public partial class Client
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
      
        [Display(Name = "الاسم الأول")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "الكنية")]
        public string LastName { get; set; } = null!;
        [Display(Name = "الايميل")]
        public string? Email { get; set; }
        [Display(Name = "رقم الهاتف")]
        public string? Phone { get; set; }
        [Display(Name = "الصورة")]
        public byte[]? Image { get; set; }
    }
}
