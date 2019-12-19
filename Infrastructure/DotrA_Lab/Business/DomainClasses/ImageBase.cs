using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotrA_Lab.Business.DomainClasses
{
    [Table("ImageBase")]
    public partial class ImageBase
    {
        [Key]
        public int ImageID { get; set; }

        public int? CatgoryID { get; set; }

        public int? ProductID { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public virtual Category Category { get; set; }

        public virtual Product Product { get; set; }
    }
}
