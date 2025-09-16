using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<SanPhamDTO>> Getallproduct()
        {
            var result = await _productRepository.GetallProduct();
            if (result == null)
            {
                throw new KeyNotFoundException("Khong co san pham nao");
            }
            var resultf = result.Select(x => new SanPhamDTO
            {
                MaSp=x.MaSp,
                TenSp = x.TenSp,
                SoLuong = x.SoLuong,
                SoLuongBan = x.SoLuongBan,
                PhanLoais = x.Phanloaisps.Select(pl => new PhanLoaiDTO
                {
                    IdPl=pl.IdPl,
                    TenPl=pl.TenPl,
                    GiaTien = pl.GiaTien
                }).ToList()
            }).ToList();
            return resultf;
        }
        public async Task<SanPhamDTO> FindbyID(int id)
        {
            var result = await _productRepository.GetbyID(id);
            if (result == null)
            {
                throw new KeyNotFoundException("Khong tim thay san pham");
            }
            return new SanPhamDTO
            {
                MaSp = result.MaSp,
                TenSp = result.TenSp,
                SoLuong = result.SoLuong,
                SoLuongBan = result.SoLuongBan,
                PhanLoais = result.Phanloaisps.Select(sp => new PhanLoaiDTO
                {
                    IdPl = sp.IdPl,
                    TenPl = sp.TenPl,
                    GiaTien=sp.GiaTien
                }).ToList()
            };
        }

        public async Task AddProductService(SanPhamRequest product)
        {
            var sp = new Sanpham
            {
                TenSp = product.TenSp,
                SoLuong = product.SoLuong,
                Phanloaisps = product.PhanLoairequest.Select(sp => new Phanloaisp
                {
                    TenPl = sp.TenPl,
                    GiaTien = sp.GiaTien,
                }).ToList(),
                MaDm = 1

            };
            await _productRepository.AddProduct(sp);
        }

        public async Task UpdateProductService(SanPhamRequest product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProductService(int id)
        {
            throw new NotImplementedException();
        }
    }
}
