using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class DonHangRepository : IDonHangRepository
    {
        private readonly AppDbContext _context;
        public DonHangRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task AddDonHang(Donhang donhang)
        {
            await _context.Donhangs.AddAsync(donhang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDonHang(int id)
        {
            var kq = await _context.Donhangs.SingleOrDefaultAsync(dh=>dh.MaDh==id);
            _context.Donhangs.Remove(kq);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donhang>> GetAllDonHang()
        {
            var kq=await _context.Donhangs.ToListAsync();
            return kq;
        }

        public async Task<Donhang> GetDonHangById(int id)
        {
            var kq=await _context.Donhangs.SingleOrDefaultAsync(dh=>dh.MaDh==id);
            return kq;
        }

        public async Task UpdateDonHang(Donhang donhang)
        {
            var query=await _context.Donhangs.SingleOrDefaultAsync(dh=>dh.MaDh==donhang.MaDh);
            query = donhang;
            await _context.SaveChangesAsync();
        }
    }
}
