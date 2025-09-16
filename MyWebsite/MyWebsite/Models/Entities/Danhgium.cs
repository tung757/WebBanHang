using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Danhgium
{
    public int Id { get; set; }

    public int? MaSp { get; set; }

    public int? MaKh { get; set; }

    public string? Content { get; set; }

    public virtual Khachhang? MaKhNavigation { get; set; }

    public virtual Sanpham? MaSpNavigation { get; set; }
}
