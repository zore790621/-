using DotrA_Lab.Business.DomainClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotrA.Areas.BackEndSystem.ViewModels
{
    public class BESMemberView
    {
        public int MemberID { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "必填欄位")]
        public string MemberAccount { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "信箱")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "地址")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "電話")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "必填欄位")]
        [Display(Name = "權限")]
        public int RoloID { get; set; }


        public virtual MemberRolo MemberRolo { get; set; }
        public Guid ActivationCode { get; internal set; }
        public string HashCode { get; set; }
        [Display(Name="信箱驗證")]
        public bool EmailVerified { get; set; }
    }
}