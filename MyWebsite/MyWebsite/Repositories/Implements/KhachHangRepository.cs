using Microsoft.EntityFrameworkCore;
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

        public async Task AddKhachHang(Khachhang khachhang)
        {
            await _context.Khachhangs.AddAsync(khachhang);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteKhachHang(int id)
        {
            var qr = await _context.Khachhangs.SingleOrDefaultAsync(kh => kh.MaKh == id);
            if (qr != null) {
                _context.Khachhangs.Remove(qr);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Khachhang>> GetAll()
        {
            var qr = await _context.Khachhangs.ToListAsync();
            return qr;
        }

        public async Task<Khachhang> GetById(int id)
        {
            var qr=await _context.Khachhangs.SingleOrDefaultAsync(kh=>kh.MaKh == id);
            return qr;
        }

        public async Task<Khachhang> GetByTk(string tk, string mk)
        {
            var qr=await _context.Khachhangs.SingleOrDefaultAsync(kh=>kh.Tk == tk&&kh.Mk==mk);
            return qr;
        }

        public async Task UpdateKhachHang(Khachhang khachhang)
        {
            var qr = await _context.Khachhangs.SingleOrDefaultAsync(kh => kh.MaKh == khachhang.MaKh);
            qr.HoTen= khachhang.HoTen;
            qr.Email= khachhang.Email;
            qr.ImgAvarta=khachhang.ImgAvarta;
            qr.DiaChi=khachhang.DiaChi;
            qr.Sdt=khachhang.Sdt;
            qr.Mk=khachhang.Mk;
            await _context.SaveChangesAsync();
        }
    }
}
