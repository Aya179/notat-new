using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NotataSub.Models
{
    public class Buying
    {

        [Display(Name = "المعرف")]
        public int Id { set; get; }
         [Display(Name = "الزبون")]
        public int clientId { set; get; }
        [Display(Name = "الكتاب")]
        public int bookID { set; get; }
        [Display(Name = "تاريخ الشراء")]
        public DateTime BuyingDate { get; set; }

    }
}
