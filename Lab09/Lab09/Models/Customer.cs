using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Customer
{
    public long Id { get; set; }
    [Display(Name = "Tên")]
    public string? Name { get; set; }
    [Display(Name = "Tên người dùng")]
    public string? Username { get; set; }
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }
    [Display(Name = "Email")]
    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public string? Phone { get; set; }
    [Display(Name = "Avatar")]
    public string? Avatar { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày cập nhật")]
    public DateTime? UpdateDate { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? Isdelete { get; set; }

    public byte? Isactive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
