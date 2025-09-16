using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Giamgium
{
    public string? IdVoucher { get; set; }

    public int? TrietKhau { get; set; }

    public int MaKh { get; set; }

    public virtual Khachhang MaKhNavigation { get; set; } = null!;
}
