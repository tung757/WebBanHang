using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private readonly AppDbContext _context;
        public GiamGiaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddGiamGia(Giamgium gia)
        {
            await _context.Giamgia.AddAsync(gia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGiamGia(int id)
        {
            var re=await _context.Giamgia.SingleOrDefaultAsync(gg=>gg.IdVoucher==id.ToString());
            _context.Giamgia.Remove(re);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Giamgium>> GetAllGiamGia()
        {
            var kq=await _context.Giamgia.ToListAsync();
            return kq;
        }

        public async Task<Giamgium> GetGiamGiaById(int id)
        {
            var kq = await _context.Giamgia.SingleOrDefaultAsync(gg => gg.IdVoucher == id.ToString());
            return kq;
        }

        public async Task UpdateGiamGia(Giamgium gia)
        {
            var kq = await _context.Giamgia.SingleOrDefaultAsync(gg => gg.IdVoucher == gia.IdVoucher);
            kq = gia;
            await _context.SaveChangesAsync();
        }
    }
}
