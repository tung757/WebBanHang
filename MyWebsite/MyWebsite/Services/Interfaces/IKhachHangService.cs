using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;

namespace MyWebsite.Services.Interfaces
{
    public interface IKhachHangService
    {
        Task<KhachHangDTO> GetKhachHang(int id);
        Task<List<KhachHangDTO>> GetAll();
        Task UpdateKhachHang(int id, KhachHangRequest khachhangDTO);
        Task DeleteKhachHang(int id);
        Task AddKhachHang(KhachHangRequest hangDTO);
    }
}
