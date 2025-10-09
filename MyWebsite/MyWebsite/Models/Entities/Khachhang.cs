using System;
using System.Collections.Generic;

namespace MyWebsite.Models.Entities;

public partial class Khachhang
{
    public int MaKh { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? Tk { get; set; }

    public string? Mk { get; set; }

    public string? ImgAvarta { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual Giohang? Giohang { get; set; }

    public virtual ICollection<Lichsumuahang> Lichsumuahangs { get; set; } = new List<Lichsumuahang>();
}
