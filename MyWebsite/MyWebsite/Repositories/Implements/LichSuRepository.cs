using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class LichSuRepository : ILichSuRepository
    {
        private readonly AppDbContext _context;
        public LichSuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lichsumuahang> GetLichSuById(int id)
        {
            var kq=await _context.Lichsumuahangs.SingleOrDefaultAsync(ls=>ls.MaLs==id);
            return kq;
        }

        public async Task<List<Lichsumuahang>> GetLichSuByIdKh(int id)
        {
            var kq=await _context.Lichsumuahangs.Where(ls=>ls.MaKh==id).ToListAsync();
            return kq;
        }
    }
}
