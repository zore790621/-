using DotrA_Lab.Business.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotrA.Models
{
    public class ProductView
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public decimal SalesPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<ImageBase> ImageBase { get; set; }
    }
}