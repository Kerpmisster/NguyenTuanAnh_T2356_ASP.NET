using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 kí tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 kí tự")]
        public string Name { get; set; }
        [Display(Name ="Địa chỉ Email")]
        [Required(ErrorMessage ="Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage ="Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name="Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
