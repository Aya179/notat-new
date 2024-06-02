using Microsoft.AspNetCore.Http;
using NotataSub.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotataSub.ViewModels
{
    public class LectureCreate
    {
        [DisplayName("الرقم")]
        [Required]
        public int LectureNum { get; set; }

        [DisplayName("العنوان")]
        [Required]
        public string Title { get; set; }

        [DisplayName("تاريخ النشر")]
        [Required]
        public DateTime? PublishDate { get; set; }

        [DisplayName("المادة")]
        [Required]
        public int? CourseId { get; set; }


        [DisplayName("عدد الصفحات")]
        [Required]
        public int? Pages { get; set; }

        public int LectureId { get; set; }
        public bool? IsDeleted { get; set; }

        [DisplayName("السعر")]
        [Required]
        public int? Price { get; set; }

        [DisplayName("الدفعة")]
        [Required]
        public int? Yearid { get; set; }
        public virtual Studyyear Year { get; set; }

        [DisplayName("صور المحاضرات")]
        public IFormFile LectureFile { get; set; }

    }
}
