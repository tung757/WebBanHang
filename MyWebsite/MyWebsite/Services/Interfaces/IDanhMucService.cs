using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;

namespace MyWebsite.Services.Interfaces
{
    public interface IDanhMucService
    {
        Task<List<DanhMucDTO>> GetAllDanhMuc();
        Task<DanhMucDTO> GetDMById(int id);
        Task AddDanhMuc(DanhMucRequest request);
        Task UpdateDanhMuc(int id, DanhMucRequest danhMucRequest);
        Task DeleteDanhMuc(int id);
    }
}
