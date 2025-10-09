using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Sanpham
{
    public int MaSp { get; set; }

    public string? TenSp { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuongBan { get; set; }

    public int MaDm { get; set; }

    public int? StatusSp { get; set; }

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual ICollection<DonhangSanpham> DonhangSanphams { get; set; } = new List<DonhangSanpham>();

    public virtual ICollection<GiohangSanpham> GiohangSanphams { get; set; } = new List<GiohangSanpham>();

    public virtual ICollection<Hinhanhsp> Hinhanhsps { get; set; } = new List<Hinhanhsp>();

    public virtual Danhmuc MaDmNavigation { get; set; } = null!;

    public virtual ICollection<Phanloaisp> Phanloaisps { get; set; } = new List<Phanloaisp>();
}
