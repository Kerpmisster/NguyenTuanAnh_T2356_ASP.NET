using System.ComponentModel.DataAnnotations;

namespace Lab09.Models
{
    public class CustomerLogin
    {
        [Required(ErrorMessage ="Địa chỉ Email không được để trống")]
        public string UserOrEmail { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
