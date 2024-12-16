using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Contact
{
    public int Id { get; set; }
    [Display(Name = "Tiêu đề")]

    public string? Title { get; set; }
    [Display(Name = "Email")]

    public string? Email { get; set; }
    [Display(Name = "Số điện thoại")]

    public string? Phone { get; set; }
    [Display(Name = "Địa chỉ")]

    public string? Address { get; set; }
    [Display(Name = "Nội dung")]

    public string? Content { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày cập nhật")]
    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
