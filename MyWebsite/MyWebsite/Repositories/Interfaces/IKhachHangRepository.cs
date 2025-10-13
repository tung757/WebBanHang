using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IKhachHangRepository
    {
        Task<List<Khachhang>> GetAll();
        Task<Khachhang> GetById(int id);
        Task<Khachhang> GetByTk(string tk, string mk);
        Task AddKhachHang(Khachhang khachhang);
        Task UpdateKhachHang(Khachhang khachhang);
        Task DeleteKhachHang(int id);
    }
}
