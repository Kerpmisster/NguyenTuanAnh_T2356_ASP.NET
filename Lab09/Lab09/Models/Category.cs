using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Category
{
    public int Id { get; set; }
    [Display(Name ="Tiêu đề")]
    public string? Title { get; set; }
    [Display(Name = "Icon")]
    public string? Icon { get; set; }
    public string? MateTitle { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }

    public int? Orders { get; set; }

    public int? Parentid { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày tạo")]
    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày cập nhật")]
    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }

    public string? Notes { get; set; }
    [Display(Name = "Trạng thái")]

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
