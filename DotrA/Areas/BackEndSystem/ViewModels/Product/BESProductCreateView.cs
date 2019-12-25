using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESProductCreateView
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "產品名稱")]
        [Required]
        [StringLength(20)]
        public string ProductName { get; set; }
        [Display(Name = "供應商")]
        [Required]
        public int SupplierID { get; set; }
        [Display(Name = "產品種類")]
        [Required]
        public int CategoryID { get; set; }

        [Display(Name = "產品進價")]
        [Required]
        public decimal UnitPrice { get; set; }
        [Display(Name = "產品描述")]
        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }
        [Display(Name = "產品數量")]
        [Required]
        public int Quantity { get; set; }
        [Display(Name = "銷售價格")]
        [Required]
        public int SalesPrice { get; set; }
        [Display(Name = "產品狀態")]
        public bool Status { get; set; }
        public IEnumerable<HttpPostedFileBase> PictureLink { get; set; }
    }
}