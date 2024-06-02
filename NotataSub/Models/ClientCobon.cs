using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NotataSub.Models
{
    public class ClientCobon
    {
        [Display(Name = "المعرف")]
        public int id { get; set; }
        [Display(Name = "الزبون")]
        public int ClientId { get; set; }
        [Display(Name = "الكوبون")]
        public int CobonId { get; set; }
        [Display(Name = "تاريخ الكوبون")]
        public DateTime CobonDate { get; set; }



    }
}
