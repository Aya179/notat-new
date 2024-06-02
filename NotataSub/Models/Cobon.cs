using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.Models
{
    public partial class Cobon
    {
        public Cobon()
        {
            StudentRegisters = new HashSet<StudentRegister>();
        }
        [Display(Name = "المعرف")]
        public int CobonId { get; set; }
        [Display(Name = "قيمة الكوبون")]
        public decimal CobonValue { get; set; }
        [Display(Name = "رقم الكوبون")]
        public string CobonNumber { get; set; } = null!;
        [Display(Name = "تفعيل")]
        public bool IsValid { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime ReleaseDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StudentRegister> StudentRegisters { get; set; }
    }
}
