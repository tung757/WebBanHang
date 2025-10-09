using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class DonhangSanpham
{
    public int MaDh { get; set; }

    public int MaSp { get; set; }

    public int? SoLuong { get; set; }

    public virtual Donhang MaDhNavigation { get; set; } = null!;

    public virtual Sanpham MaSpNavigation { get; set; } = null!;
}
