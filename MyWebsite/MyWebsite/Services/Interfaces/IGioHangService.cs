using MyWebsite.Models.DTOs;
using MyWebsite.Models.Requests;

namespace MyWebsite.Services.Interfaces
{
    public interface IGioHangService
    {
        Task<List<GioHangSanPhamDTO>> GetGioHangByIdKH(int id);
        Task AddItemGioHang(GioHangSanPhamRequest request);
        Task DeleteItemGioHang(GioHangSanPhamRequest request);
        Task UpdateItemGioHang(GioHangSanPhamRequest request);
    }
}
