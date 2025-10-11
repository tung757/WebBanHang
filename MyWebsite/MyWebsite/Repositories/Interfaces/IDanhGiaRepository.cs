using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IDanhGiaRepository
    {
        Task<List<Danhgium>> GetByIdProduct(int id);
        Task AddDanhGia(Danhgium danhgia);
        Task UpdateDanhGia(int id, Danhgium danhgia);
        Task DeleteDanhGia(int id);
        Task<Danhgium> GetDanhGiaById(int id);
    }
}
