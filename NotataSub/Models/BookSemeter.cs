using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NotataSub.Models
{
    public class BookSemeter
    {
        public int id { get; set; }
        [Display(Name = "عنوان الفصل")]
        public string semeterTitel { get; set; }
        [Display(Name = "رقم الصفحة")]
        public int pagenum { get; set; }
        [Display(Name = "الكتاب")]
        public string bookTitle { get; set; }
       // public virtual Book? book2 { get; set; }



    }
}
