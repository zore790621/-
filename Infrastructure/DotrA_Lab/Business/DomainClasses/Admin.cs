using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA_Lab.Business.DomainClasses
{
    [Table("Admin")]
    public partial class Admin
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(20)]
        public string AdminAccount { get; set; }

        [Required]
        [StringLength(20)]
        public string AdminPW { get; set; }
    }
}
