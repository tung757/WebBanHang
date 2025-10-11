using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class DanhGiaRepository : IDanhGiaRepository
    {
        private readonly AppDbContext _context;
        public DanhGiaRepository(AppDbContext context) { 
            _context = context;
        }
        public async Task AddDanhGia(Danhgium danhgia)
        {
            await _context.Danhgia.AddAsync(danhgia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDanhGia(int id)
        {
            var kq= await _context.Danhgia.SingleOrDefaultAsync(dg=>dg.Id==id);
            _context.Danhgia.Remove(kq);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Danhgium>> GetByIdProduct(int id)
        {
            var kq = await _context.Danhgia.Where(sp => sp.MaSp == id).ToListAsync();
            return kq;
        }

        public async Task<Danhgium> GetDanhGiaById(int id)
        {
            var kq=await _context.Danhgia.SingleOrDefaultAsync(dg=>dg.Id == id);
            return kq;
        }

        public async Task UpdateDanhGia(int id, Danhgium danhgia)
        {
            var kq= await _context.Danhgia.SingleOrDefaultAsync(danhgia=>danhgia.Id==id);
            kq = danhgia;
            await _context.SaveChangesAsync();
        }
    }
}
