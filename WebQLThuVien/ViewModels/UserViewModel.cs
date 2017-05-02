using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQLThuVien.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên người dùng")]
        [Required,StringLength(20, MinimumLength = 6)]
        public string Fullname { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [StringLength(20, MinimumLength = 6)]
        public string RePassword { get; set; }
    }

    public class CreateUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required, StringLength(20, MinimumLength = 6), RegularExpression("^[A-Za-z0-9_]+$")]
        public string Username { get; set; }

        [Display(Name = "Tên người dùng")]
        [Required, StringLength(20, MinimumLength = 6)]
        public string Fullname { get; set; }

        [Display(Name = "Địa chỉ Email")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required, StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Required, StringLength(20, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu không chính xác!")]
        public string RePassword { get; set; }
    }
}