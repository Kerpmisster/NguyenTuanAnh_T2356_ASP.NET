using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Customer
{
    public long Id { get; set; }
    [Display(Name = "Tên")]

    public string? Name { get; set; }
    [Display(Name = "Tài khoản")]

    public string? Username { get; set; }
    [Display(Name = "Mật khẩu")]

    public string? Password { get; set; }
    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
    [Display(Name = "Ảnh")]
    public string? Avatar { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian tạo")]
    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian sửa")]
    public DateTime? UpdateDate { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public byte? Isdelete { get; set; }

    public byte? Isactive { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
