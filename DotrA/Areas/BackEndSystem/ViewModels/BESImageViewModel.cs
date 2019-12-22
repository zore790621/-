using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESImageViewModel
    {
        [Key]
        public int ImageID { get; set; }
        public int? CatgoryID { get; set; }

        public int? ProductID { get; set; }

        [Required]
        public string ImageName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}