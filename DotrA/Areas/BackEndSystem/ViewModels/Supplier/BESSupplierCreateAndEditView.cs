using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESSupplierCreateAndEditView
    {
        public int SupplierID { get; set; }

        [Display(Name = "廠商名稱")]
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Display(Name = "聯絡電話")]
        [StringLength(50)]
        public string CampanyPhone { get; set; }

        [Display(Name = "聯絡地址")]
        [StringLength(20)]
        public string CompanyAddress { get; set; }
    }
}