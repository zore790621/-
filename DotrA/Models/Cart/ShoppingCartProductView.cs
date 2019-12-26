using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotrA.Models.Cart
{
    public class ShoppingCartProductView
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SalesPrice { get; set; }
    }
}