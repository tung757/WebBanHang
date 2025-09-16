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
            if (product == null) { throw new ArgumentNullException(nameof(product)); }
            var result = await _context.Sanphams.Include(sp=>sp.Phanloaisps).SingleOrDefaultAsync(sp=>sp.MaSp==product.MaSp);
            if (result == null) { throw new Exception("Sản phẩm không tồn tại"); }
            result.TenSp=product.TenSp;
            result.SoLuong=product.SoLuong;
            var toRemove = result.Phanloaisps.Where(pl => !product.Phanloaisps.Any(p => p.IdPl == pl.IdPl)).ToList();
            foreach (var pl in toRemove) { 
                _context.Phanloaisps.Remove(pl);
            }
            foreach (var pl in result.Phanloaisps) {
                if (pl.IdPl == 0)
                {
                    _context.Phanloaisps.Add(pl);
                }
                else
                {
                    var qrpl = await _context.Phanloaisps.SingleOrDefaultAsync(p=>p.IdPl == pl.IdPl);
                    if (qrpl == null)
                    {
                        throw new Exception("Không thể tỉm thấy phân loại");
                    }
                    qrpl.TenPl= pl.TenPl;
                    qrpl.GiaTien= pl.GiaTien;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sanpham>> GetallProduct()
        {
            var result = await _context.Sanphams.Include(sp=> sp.Phanloaisps).ToListAsync();
            return result;
        }

        public async Task<Sanpham> GetbyID(int id)
        {
            var result = await _context.Sanphams.Include(sp=> sp.Phanloaisps).SingleOrDefaultAsync(sp => sp.MaSp == id);
            if (result == null)
            {
                throw new Exception("Khong tim thay san pham nay");
            }
            return result;
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _context.Sanphams.Include(sp=> sp.Phanloaisps).SingleOrDefaultAsync();
            if(result == null)
            {
                throw new Exception("Khong tim thay san pham de xoa");
            }
            _context.Sanphams.Remove(result);
        }
    }
}
