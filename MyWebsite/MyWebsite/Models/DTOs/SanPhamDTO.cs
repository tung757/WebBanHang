namespace MyWebsite.Models.DTOs
{
    public class SanPhamDTO
    {
        public int MaSp { get; set; }
        public string? TenSp { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongBan { get; set; }

        public List<PhanLoaiDTO>? PhanLoais { get; set; }
    }
}
