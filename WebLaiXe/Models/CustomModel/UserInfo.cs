using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLaiXe.Models
{
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name ="Tên Đăng Nhập")]
        [Required(ErrorMessage ="Bạn Phải Nhập Tài Khoản")]
        public string UserName { get; set; }
        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "Bạn Phải Nhập Mật Khẩu")]
        public string PassWord { get; set; }
        public string DisplayName { get; set; }

    }
}