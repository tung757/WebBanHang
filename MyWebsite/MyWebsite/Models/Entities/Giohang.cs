using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Giohang
{
    public int IdGh { get; set; }

    public int MaKh { get; set; }

    public double? TongTien { get; set; }

    public virtual ICollection<GiohangSanpham> GiohangSanphams { get; set; } = new List<GiohangSanpham>();

    public virtual Khachhang MaKhNavigation { get; set; } = null!;
}
