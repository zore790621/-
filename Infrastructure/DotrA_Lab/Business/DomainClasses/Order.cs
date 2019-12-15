using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotrA_Lab.Business.DomainClasses
{
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
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

        public int PaymentID { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
