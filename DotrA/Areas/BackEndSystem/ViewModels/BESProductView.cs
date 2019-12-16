﻿using DotrA_Lab.Business.DomainClasses;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESProductView
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


        [Display(Name = "產品圖片")]
        public string Picture { get; set; }


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

        public HttpPostedFileBase PictureLink { get; set; }

        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}