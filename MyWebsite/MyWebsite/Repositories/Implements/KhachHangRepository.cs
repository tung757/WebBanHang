using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly AppDbContext _context;
        public KhachHangRepository(AppDbContext context) { 
            _context = context;
        }

        public Task AddKhachHang(Khachhang khachhang)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKhachHang(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Khachhang>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Khachhang> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateKhachHang(Khachhang khachhang)
        {
            throw new NotImplementedException();
        }
    }
}
