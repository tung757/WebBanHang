using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IDonHangRepository
    {
        Task<List<Donhang>> GetAllDonHang();
        Task<Donhang> GetDonHangById(int id);
        Task AddDonHang(Donhang donhang);
        Task UpdateDonHang(Donhang donhang);
        Task DeleteDonHang(int id);
    }
}
