﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotrA.Models
{
    public class MemberModifyViewModel
    {

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20)]
        public string MemberAccount { get; set; }
        [Display(Name = "原始密碼密碼")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "必填欄位")]
        public string Password { get; set; }
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
        [Display(Name = "需修改密碼")]
        [StringLength(20)]
        public string RePassword { get; set; }
    }
}