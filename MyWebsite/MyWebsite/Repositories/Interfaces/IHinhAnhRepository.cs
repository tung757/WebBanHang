using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IHinhAnhRepository
    {
        Task<List<Hinhanhsp>> GetHinhAnhByIdSp(int id);
        Task DeleteHinhAnh(int id);
        Task<Hinhanhsp> GetHinhAnhById(int id);
        Task AddHinhAnh(Hinhanhsp entity);
        Task UpdateHinhAnh(Hinhanhsp hinhanhsp);
    }
}
