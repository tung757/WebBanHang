using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Danhmuc
{
    public int MaDm { get; set; }

    public string? TenDm { get; set; }

    public string? ImgDm { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
