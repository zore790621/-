using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESSupplierView
    {
        public int SupplierID { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CampanyPhone { get; set; }

        [StringLength(20)]
        public string CompanyAddress { get; set; }
    }
}
