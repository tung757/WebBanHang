using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class GiohangSanpham
{
    public int MaSp { get; set; }

    public int IdGh { get; set; }

    public int? SoLuong { get; set; }

    public virtual Giohang IdGhNavigation { get; set; } = null!;

    public virtual Sanpham MaSpNavigation { get; set; } = null!;
}
