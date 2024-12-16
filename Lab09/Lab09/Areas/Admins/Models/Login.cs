using System.ComponentModel.DataAnnotations;

namespace Lab09.Areas.Admins.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Địa chỉ Email không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
