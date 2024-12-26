using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Partner
{
    public int Id { get; set; }
    [Display(Name = "Tiêu đề")]
    public string? Title { get; set; }

    public string? Logo { get; set; }

    public string? Url { get; set; }

    public byte? Orders { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian tạo")]

    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian sửa")]

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Nội dung")]

    public string? Content { get; set; }
    [Display(Name = "Trạng thái")]

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }
}
