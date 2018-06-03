using System;
using System.ComponentModel.DataAnnotations;

namespace SomeeMVC_4.Models
{
    public class UsersModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [RegularExpression(@"^([a-zA-Z_0-9])$", ErrorMessage = "Tên đăng nhập không được chứa ký tự đặc biệt!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"^([a-zA-Z_0-9\.]+)@([a-zA-Z_0-9\.]+)\.([a-zA-Z_0-9\.]+)$", ErrorMessage = "Email không đúng định dạng!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tên hiển thị không được để trống!")]
        public string DisplayName { get; set; }

        public Nullable<bool> Status { get; set; }
    }
}