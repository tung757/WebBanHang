using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Lichsumuahang
{
    public int MaLs { get; set; }

    public DateOnly? NgayMua { get; set; }

    public int MaKh { get; set; }

    public virtual Khachhang MaKhNavigation { get; set; } = null!;
}
