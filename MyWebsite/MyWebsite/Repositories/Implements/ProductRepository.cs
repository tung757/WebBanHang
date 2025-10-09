using Microsoft.EntityFrameworkCore;
using MyWebsite.Models.Entities;
using MyWebsite.Repositories.Interfaces;

namespace MyWebsite.Repositories.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Sanpham product)
        {
            if (product == null) { throw new ArgumentNullException(nameof(product)); }
            await _context.Sanphams.AddAsync(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message;
                throw new Exception($"SaveChanges failed: {inner}", ex);
            }
        }
        public async Task UpdateProduct(Sanpham product)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sanpham>> GetallProduct()
        {
            var result = await _context.Sanphams.Include(sp => sp.Phanloaisps).ToListAsync();
            return result;
        }

        public async Task<Sanpham> GetbyID(int id)
        {
            var result = await _context.Sanphams.Include(sp => sp.Phanloaisps).SingleOrDefaultAsync(sp => sp.MaSp == id);
            if (result == null)
            {
                throw new Exception("Khong tim thay san pham theo "+id);
            }
            return result;
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _context.Sanphams.Include(sp => sp.Phanloaisps).SingleOrDefaultAsync(sp=>sp.MaSp==id);
            if (result == null)
            {
                throw new Exception("Khong tim thay san pham de xoa");
            }
            _context.Sanphams.Remove(result);
            _context.SaveChanges();
        }

        public void DetetePhanLoai(Phanloaisp phanloaisp)
        {
            _context.Phanloaisps.Remove(phanloaisp);
        }

        public async Task<List<Sanpham>> getSanPhambyDanhMuc(int id)
        {
            return await _context.Sanphams.Where(sp => sp.MaDm == id).Include(sp=>sp.Phanloaisps).ToListAsync();
        }
    }
}
