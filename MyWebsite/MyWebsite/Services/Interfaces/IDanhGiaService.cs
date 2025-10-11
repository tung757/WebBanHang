using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;

namespace MyWebsite.Services.Interfaces
{
    public interface IDanhGiaService
    {
        Task<List<DanhGiaDTO>> GetByIdProductService(int id);
        Task AddDanhGia(DanhGiaRequest danhgia);
        Task UpdateDanhGia(int id, DanhGiaRequest danhgia);
        Task DeleteDanhGia(int id);
    }
}
