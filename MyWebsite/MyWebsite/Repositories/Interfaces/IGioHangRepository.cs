using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IGioHangRepository
    {
        Task<Giohang> GetGiohangByIdKH(int id);
        Task AddGioHang(int id);
    }
}
