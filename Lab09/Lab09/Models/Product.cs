using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Product
{
    public int Id { get; set; }
    [Display(Name = "Danh mục")]

    public int? Cid { get; set; }

    public string? Code { get; set; }
    [Display(Name = "Tiêu đề")]

    public string? Title { get; set; }
    [Display(Name = "Mô tả")]

    public string? Description { get; set; }
    [Display(Name = "Nội dung")]

    public string? Content { get; set; }
    [Display(Name = "Ảnh")]

    public string? Image { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Slug { get; set; }
    [Display(Name = "Gía cũ")]

    public decimal? PriceOld { get; set; }
    [Display(Name = "Gía mới")]

    public decimal? PriceNew { get; set; }

    public string? Size { get; set; }

    public int? Views { get; set; }

    public int? Likes { get; set; }

    public double? Star { get; set; }

    public byte? Home { get; set; }

    public byte? Hot { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian tạo")]

    public DateTime? CreatedDate { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Thời gian sửa")]

    public DateTime? UpdatedDate { get; set; }

    public string? AdminCreated { get; set; }

    public string? AdminUpdated { get; set; }
    [Display(Name = "Trạng thái")]

    public byte? Status { get; set; }

    public bool? Isdelete { get; set; }

    public virtual Category? CidNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
