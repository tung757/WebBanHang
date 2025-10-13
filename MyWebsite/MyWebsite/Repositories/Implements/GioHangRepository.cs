using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly AppDbContext _context;
        public GioHangRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddGioHang(int id)
        {
            Giohang giohang = new Giohang();
            giohang.MaKh = id;
            await _context.Giohangs.AddAsync(giohang);
            await _context.SaveChangesAsync();
        }

        public async Task<Giohang> GetGiohangByIdKH(int id)
        {
            var kq=await _context.Giohangs.SingleOrDefaultAsync(gh=>gh.MaKh==id);
            return kq;
        }
    }
}
