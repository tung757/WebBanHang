namespace MyWebsite.Models.Requests
{
    public class SanPhamRequest
    {
        public string? TenSp { get; set; }

        public int? SoLuong { get; set; }

        public int? SoLuongBan { get; set; }

        public List<PhanLoaiRequest>? PhanLoairequest { get; set; }
    }
}
