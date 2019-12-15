using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA_Lab.Business.DomainClasses
{
    [Table("MemberRolo")]
    public partial class MemberRolo
    {
        [Key]
        [Column(Order = 0)]
        public int RoloID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string RoloName { get; set; }
    }
}
