using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 kí tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 kí tự")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name ="Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        public string Phone { get; set; }
        [Display(Name ="Địa chỉ thường trú")]
        [Required(ErrorMessage ="Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage ="Địa chỉ không vượt quá 35 ký tự")]
        public string Address { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }
        [Display(Name ="Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Link Facebook cá nhân")]
        [Required(ErrorMessage ="Link Facebook không được để trống")]
        [Url(ErrorMessage ="Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/tuananh")]
        public string Facebook { get; set; }
    }
}
