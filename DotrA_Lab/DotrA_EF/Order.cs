using System.ComponentModel.DataAnnotations;

namespace DotrA_Lab.DotrA_EF
{
    public partial class Order
    {
        public int OrderID { get; set; }

        public int MemberID { get; set; }

        public int ShipperID { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientName { get; set; }

        [Required]
        [StringLength(20)]
        public string RecipientPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientAddress { get; set; }

        public virtual Member Member { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
