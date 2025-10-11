using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IGiamGiaRepository
    {
        Task<List<Giamgium>> GetAllGiamGia();
        Task<Giamgium> GetGiamGiaById(int id);
        Task AddGiamGia(Giamgium gia);
        Task DeleteGiamGia(int id);
        Task UpdateGiamGia(Giamgium gia);
    }
}
