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
        public async Task<Giohang> GetGiohangById(int id)
        {
            var kq=await _context.Giohangs.SingleOrDefaultAsync(gh=>gh.IdGh==id);
            return kq;
        }
    }
}
