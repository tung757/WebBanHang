using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IDonHangItemRepository
    {
        Task<List<DonhangSanpham>> GetAllDonHang_SanPham();
        Task<DonhangSanpham> GetDonHang_SanPhamById(int MaDh, int MaSp);
        Task UpdateDonHang_SanPham(DonhangSanpham donhangSanpham);
        Task AddDonHang_SanPham(DonhangSanpham donhangSanpham);
        Task DeleteDonHang_SanPham(int MaDh, int MaSp);
    }
}
