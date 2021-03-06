using DotrA_Lab.Business.DomainClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESOrderDetailView
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public short Quantity { get; set; }

        public float? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
