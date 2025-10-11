namespace MyWebsite.Models.Requests
{
    public class DonHangRequest
    {
        public DateOnly? NgayLap { get; set; }

        public int? TrangThai { get; set; }

        public int? ThanhToan { get; set; }

        public int MaKh { get; set; }
    }
}
