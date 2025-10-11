using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface ILichSuRepository
    {
        Task<List<Lichsumuahang>> GetLichSuByIdKh(int id);
        Task<Lichsumuahang> GetLichSuById(int id);
    }
}
