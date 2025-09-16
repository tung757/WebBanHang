using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Hinhanhsp
{
    public int IdImg { get; set; }

    public string? ImgAnh { get; set; }

    public int MaSp { get; set; }

    public virtual Sanpham MaSpNavigation { get; set; } = null!;
}
