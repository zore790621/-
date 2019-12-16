using DotrA_Lab.Business.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESOrderView
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

        public int PaymentID { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Member Member { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
