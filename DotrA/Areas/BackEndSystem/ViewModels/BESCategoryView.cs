using DotrA_Lab.Business.DomainClasses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESCategoryView
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "類別名稱")]
        public string CategoryName { get; set; }

        [StringLength(255)]
        [Display(Name = "類別描述")]
        public string Categorydescript { get; set; }

        [Display(Name = "圖片")]
        public IEnumerable<HttpPostedFileBase> PictureLink { get; set; }

        [Display(GroupName ="名稱")]
        public virtual ICollection<ImageBase> ImageBase { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}