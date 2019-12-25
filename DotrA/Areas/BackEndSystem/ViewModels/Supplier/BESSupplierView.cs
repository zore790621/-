using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESSupplierView
    {
        public int SupplierID { get; set; }

        [Display(Name = "�t�ӦW��")]
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Display(Name = "�p���q��")]
        [StringLength(50)]
        public string CampanyPhone { get; set; }

        [Display(Name = "�p���a�}")]
        [StringLength(20)]
        public string CompanyAddress { get; set; }

        [Display(Name = "�������~")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
