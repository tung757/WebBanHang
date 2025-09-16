using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Phanloaisp
{
    public int IdPl { get; set; }

    public string? TenPl { get; set; }

    public double? GiaTien { get; set; }

    public int MaSp { get; set; }

    public virtual Sanpham MaSpNavigation { get; set; } = null!;
}
