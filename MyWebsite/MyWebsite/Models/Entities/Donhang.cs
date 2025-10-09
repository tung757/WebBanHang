using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Donhang
{
    public int MaDh { get; set; }

    public DateOnly? NgayLap { get; set; }

    public int? TrangThai { get; set; }

    public int? ThanhToan { get; set; }

    public int MaKh { get; set; }

    public virtual ICollection<DonhangSanpham> DonhangSanphams { get; set; } = new List<DonhangSanpham>();

    public virtual Khachhang MaKhNavigation { get; set; } = null!;
}
