using DotrA_Lab.Business.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotrA.Models
{
    public class ProductListView
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}