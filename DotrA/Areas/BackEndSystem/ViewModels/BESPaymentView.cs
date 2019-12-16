using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESPaymentView
    {

        public int PaymentID { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentMethod { get; set; }
    }
}
