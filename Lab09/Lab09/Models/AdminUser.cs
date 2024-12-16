using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class AdminUser
{
    public int Id { get; set; }
    [Display(Name = "Tài khoản")]
    public string? Account { get; set; }
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    public int? MaNhanSu { get; set; }
    [Display(Name = "Tên")]
    public string? Name { get; set; }
    [Display(Name = "Số điện thoại")]

    public string? Phone { get; set; }
    [Display(Name = "Email")]

    public string? Email { get; set; }
    [Display(Name = "Avatar")]

    public string? Avatar { get; set; }

    public int? IdPhongBan { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public string? SessionToken { get; set; }

    public string? Salt { get; set; }

    public bool? IsAdmin { get; set; }

    public int? TrangThai { get; set; }

    public bool? IsDelete { get; set; }
}
