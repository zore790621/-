using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESShipperView
    {
        public int ShipperID { get; set; }

        [Required]
        [StringLength(20)]
        public string ShipperName { get; set; }
    }
}
