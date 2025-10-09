using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IDanhMucRepository
    {
        Task<List<Danhmuc>> getAllDM();
        Task<Danhmuc> getDMbyID(int ID);
        Task AddDM(Danhmuc danhmuc);
        Task UpdateDM(Danhmuc danhmuc);
        Task DeleteDM(int ID);
    }
}
