using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab09.Models;

public partial class Order
{
    public long Id { get; set; }

    public long? IdOrders { get; set; }

    public long? IdCustomer { get; set; }

    public long? IdPayment { get; set; }
    [Display(Name = "Ngày đặt")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? OrdersDate { get; set; }
    [Display(Name = "Tổng tiền")]
    public decimal? TotalMoney { get; set; }

    public string? Notes { get; set; }
    [Display(Name = "Người nhận")]
    public string? NameReciver { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public byte? Isdelete { get; set; }

    public byte? Isactive { get; set; }
    [ValidateNever]
    public virtual Customer? IdOrdersNavigation { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
