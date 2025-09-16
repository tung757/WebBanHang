using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;

namespace MyWebsite.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<SanPhamDTO>> Getallproduct();
        Task<SanPhamDTO> FindbyID(int id);
        Task AddProductService(SanPhamRequest product);
        Task UpdateProductService(SanPhamRequest product);
        Task DeleteProductService(int id);
    }
}
