

using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class DanhMucRepository : IDanhMucRepository
    {
        private readonly AppDbContext _context;
        public DanhMucRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddDM(Danhmuc danhmuc)
        {
            await _context.Danhmucs.AddAsync(danhmuc);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDM(int ID)
        {
            var result = await _context.Danhmucs.SingleOrDefaultAsync(dm => dm.MaDm == ID);
            _context.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Danhmuc>> getAllDM()
        {
            return await _context.Danhmucs.ToListAsync();
        }

        public async Task<Danhmuc> getDMbyID(int ID)
        {
            return await _context.Danhmucs.SingleOrDefaultAsync(dm=>dm.MaDm==ID);
        }

        public async Task UpdateDM(Danhmuc danhmuc)
        {
            var result= await _context.Danhmucs.SingleOrDefaultAsync(dm=>dm.MaDm==danhmuc.MaDm);
            result = danhmuc;
            await _context.SaveChangesAsync();
        }
    }
}
