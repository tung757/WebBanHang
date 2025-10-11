using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IGioHangRepository
    {
        Task<Giohang> GetGiohangById(int id);

    }
}
