using MyWebsite.Models.Entities;

namespace MyWebsite.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Sanpham>> GetallProduct();
        Task<Sanpham> GetbyID(int id);
        Task AddProduct(Sanpham product);
        Task UpdateProduct(Sanpham product);
        Task DeleteProduct(int id);
        void DetetePhanLoai(Phanloaisp phanloaisp);
        Task<List<Sanpham>> getSanPhambyDanhMuc(int id);
    }
}
