using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class GioHangItemRepository : IGioHangItemRepository
    {
        private readonly AppDbContext _context;
        public GioHangItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddItemGioHang(GiohangSanpham ghsp)
        {
            await _context.GiohangSanphams.AddAsync(ghsp);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GiohangSanpham>> GetAllItemsGioHangByIDGioHang(int MaGh)
        {
            var kq = await _context.GiohangSanphams.Where(item=>item.IdGh==MaGh).ToListAsync();
            return kq;
        }

        public async Task RemoveItemGioHang(int IdGh, int MaSp)
        {
            var kq = await _context.GiohangSanphams.SingleOrDefaultAsync(gh => gh.IdGh == IdGh && gh.MaSp == MaSp);
            _context.GiohangSanphams.Remove(kq);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemGioHang(GiohangSanpham ghsp)
        {
            var kq = await _context.GiohangSanphams.SingleOrDefaultAsync(gh => gh.IdGh == ghsp.IdGh && gh.MaSp == ghsp.MaSp);
            kq.SoLuong = ghsp.SoLuong;
            await _context.SaveChangesAsync();
        }
    }
}
