using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA_Lab.Business.DomainClasses
{
    public partial class OrderDetails
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public short Quantity { get; set; }

        public float? Discount { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Products Products { get; set; }
    }
}
