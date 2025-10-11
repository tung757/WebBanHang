using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;
using System;

namespace MyWebsite.Repositories.Implements
{
    public class DonHangItemRepository : IDonHangItemRepository
    {
        private readonly AppDbContext _context;
        public DonHangItemRepository(AppDbContext context) { 
            _context = context;
        }
        public async Task AddDonHang_SanPham(DonhangSanpham donhangSanpham)
        {
            var kq= await _context.DonhangSanphams.AddAsync(donhangSanpham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDonHang_SanPham(int MaDh, int MaSp)
        {
            var re = await _context.DonhangSanphams.SingleOrDefaultAsync(dh => dh.MaDh == MaDh && dh.MaSp == MaSp);
            _context.DonhangSanphams.Remove(re);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DonhangSanpham>> GetAllDonHang_SanPham()
        {
            var kq=await _context.DonhangSanphams.ToListAsync();
            return kq;
        }

        public async Task<DonhangSanpham> GetDonHang_SanPhamById(int MaDh, int MaSp)
        {
            var kq=await _context.DonhangSanphams.SingleOrDefaultAsync(dh=>dh.MaDh==MaDh && dh.MaSp==MaSp);
            return kq;
        }

        public async Task UpdateDonHang_SanPham(DonhangSanpham donhangSanpham)
        {
            var kq = await _context.DonhangSanphams.SingleOrDefaultAsync(dh => dh.MaDh == donhangSanpham.MaDh && dh.MaSp == donhangSanpham.MaSp);
            kq = donhangSanpham;
            await _context.SaveChangesAsync();
        }
    }
}
