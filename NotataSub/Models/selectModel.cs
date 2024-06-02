using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NotataSub.Models
{
    public class selectModel
    {
        [Display(Name = "قيمة الكوبون")]

        public decimal cobonvalue { get; set; }
        [Display(Name = "العدد")]

        public int coboncount { get; set; }
        [Display(Name = "التاريخ")]

        public DateTime ReleaseDate { get; set; }
        public int CobonId { get; set; }
        public int id { get; set; }
        public int clientId { get; set; }
        public int BookId{ get; set; }
        [Display(Name = "عنوان الكتاب")]
        public string Booktitle{ get; set; }
        [Display(Name = "اسم الزبون")]
        public string clientName{ get; set; }
        [Display(Name = "تاريخ الشراء")]
        public DateTime BuyingDate{ get; set; }
        public decimal BookPrice{ get; set; }
        public int count { get; set; }
        [Display(Name = "المؤلف")]
        public string auther { get; set; }

        [Display(Name = "إجمالي المبيعات")]
        public float Total { get; set; }
        [Display(Name = "رقم الكوبون")]
        public string CobonNumber { get; set; }



    }
}
