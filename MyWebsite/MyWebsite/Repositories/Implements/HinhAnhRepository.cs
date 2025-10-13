using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class HinhAnhRepository : IHinhAnhRepository
    {
        private readonly AppDbContext _context;
        public HinhAnhRepository(AppDbContext context) { 
            _context = context;
        
        }

        public async Task AddHinhAnh(Hinhanhsp entity)
        {
            await _context.Hinhanhsps.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHinhAnh(int id)
        {
            var kq=await _context.Hinhanhsps.SingleOrDefaultAsync(ha=>ha.IdImg==id);
            _context.Hinhanhsps.Remove(kq);
            await _context.SaveChangesAsync();
        }

        public async Task<Hinhanhsp> GetHinhAnhById(int id)
        {
            var kq=await _context.Hinhanhsps.FirstOrDefaultAsync(ha=>ha.IdImg==id);
            return kq;
        }

        public async Task<List<Hinhanhsp>> GetHinhAnhByIdSp(int id)
        {
            var kq=await _context.Hinhanhsps.Where(ha=>ha.MaSp==id).ToListAsync();
            return kq;
        }

        public async Task UpdateHinhAnh(Hinhanhsp hinhanhsp)
        {
            var kq = await _context.Hinhanhsps.SingleOrDefaultAsync(ha => ha.IdImg == hinhanhsp.IdImg);
            kq = hinhanhsp;
            await _context.SaveChangesAsync();
        }
    }
}
