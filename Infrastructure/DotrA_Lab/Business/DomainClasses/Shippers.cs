using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotrA_Lab.Business.DomainClasses
{
    public partial class Shippers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int ShipperID { get; set; }

        [Required]
        [StringLength(20)]
        public string ShipperName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
