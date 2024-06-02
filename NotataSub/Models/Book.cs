using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace NotataSub.Models
{
    public partial class Book
    {
        //public Book()
        //{
        //    BookSemeters=new HashSet<BookSemeter>();
        //}
        [Display(Name ="المعرف")]
        public int Id { get; set; }
        [Display(Name = " الفئة")]
        public int CatId { get; set; }
        
        [Display(Name = "عنوان الكتاب")]
        public string? Title { get; set; }
        [Display(Name = "عددالصفحات")]
        public int? Pages { get; set; }
        [Display(Name = "سعر الكتاب")]
        public int? Price { get; set; }
        [Display(Name = "سنة النشر")]
        public DateTime? Year { get; set; }
        public string? IsDeleted { get; set; }
        public string Linkurl { get; set; } = null!;
        [Display(Name = "صورة الغلاف")]
        public byte[]? Image { get; set; }
        [Display(Name ="المؤلفين الآخرين")]
        public string? OtherWriter { get; set; }
        [DisplayName("اسم المؤلف")]
        public string WriterName { get; set; }
        [Display(Name = " الفئة الفرعية")]
        public int subId { get; set; }
        public virtual Catogary? Cat { get; set; }
        public virtual SubCatogary? Sub { get; set; }
       // public virtual ICollection<BookSemeter> BookSemeters { get; set; }
    }
}
