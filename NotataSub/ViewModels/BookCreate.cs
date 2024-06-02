using Microsoft.AspNetCore.Http;
using NotataSub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotataSub.ViewModels
{
    public class BookCreate
    {

        public int? CatId { get; set; }
        public int? WritreId { get; set; }
        public string? Title { get; set; }
        public int? Pages { get; set; }
        public int? Price { get; set; }
        public DateTime? Year { get; set; }
        public string? IsDeleted { get; set; }

        public virtual Catogary? Cat { get; set; }
        public virtual Writer? Writre { get; set; }

        [DisplayName("صور الكتاب")]
        public IFormFile BookFile { get; set; }
        [Display(Name = "صورة الغلاف")]
        public byte[]? Image { get; set; }


        [DisplayName("نموذج مجاني")]
        public IFormFile? BookDescreption { get; set; }
        [DisplayName("لمحة عن الكتاب")]
        public string? OtherWriter { get; set; }

        [DisplayName("اسم المؤلف")]
        public string? WriterName { get; set; }
        public int subId { get; set; }

        public string Linkurl { get; set; } = null!;
    }
}
