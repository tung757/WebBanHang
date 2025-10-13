using Azure.Core;
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
        private readonly IHinhAnhRepository _hinhAnhRepository;
        public ProductService(IProductRepository productRepository, IHinhAnhRepository hinhAnhRepository)
        {
            _productRepository = productRepository;
            _hinhAnhRepository = hinhAnhRepository;
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
                MaSp = x.MaSp,
                TenSp = x.TenSp,
                SoLuong = x.SoLuong,
                SoLuongBan = x.SoLuongBan,
                PhanLoais = x.Phanloaisps.Select(pl => new PhanLoaiDTO
                {
                    IdPl = pl.IdPl,
                    TenPl = pl.TenPl,
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
                    GiaTien = sp.GiaTien
                }).ToList()
            };
        }

        public async Task AddProductService(SanPhamRequest product)
        {
            var sp = new Sanpham
            {
                TenSp = product.TenSp,
                SoLuong = product.SoLuong,
                Phanloaisps = product.Phanloairqs.Select(sp => new Phanloaisp
                {
                    TenPl = sp.TenPl,
                    GiaTien = sp.GiaTien,
                }).ToList(),
                MaDm = 1

            };
            await _productRepository.AddProduct(sp);
        }

        public async Task UpdateProductService(int id, SanPhamRequest product)
        {
            var entity = await _productRepository.GetbyID(id);
            if (entity == null)
            {
                throw new Exception("Khong tim thay san pham bang id de update");
            }
            entity.TenSp = product.TenSp;
            entity.SoLuong = product.SoLuong;
            entity.SoLuongBan = product.SoLuongBan;
            var phanloaiids = product.Phanloairqs.Where(p => p.IdPl > 0).Select(p => p.IdPl).ToList();
            var toRemove = entity.Phanloaisps.Where(pl => !phanloaiids.Contains(pl.IdPl));
            if (toRemove != null)
            {

                foreach (var rm in toRemove)
                {
                    _productRepository.DetetePhanLoai(rm);
                }
            }
            foreach (var pl in entity.Phanloaisps)
            {
                var reqPl = product.Phanloairqs.SingleOrDefault(r => r.IdPl == pl.IdPl);
                if (reqPl != null)
                {
                    pl.TenPl = reqPl.TenPl;
                    pl.GiaTien = reqPl.GiaTien;
                }
            }

            var newPls = product.Phanloairqs.Where(r => r.IdPl == 0).ToList();
            if (newPls != null)
            {
                foreach (var pl in newPls)
                {
                    entity.Phanloaisps.Add(new Phanloaisp
                    {
                        TenPl = pl.TenPl,
                        GiaTien = pl.GiaTien,
                        MaSp = entity.MaSp
                    });
                }
            }

            await _productRepository.UpdateProduct(entity);
        }
        public async Task DeleteProductService(int id)
        {
            var sp= await _productRepository.GetbyID(id);
            if (sp == null)
            {
                throw new Exception("Khong tim thay san pham de xoa service");
            }
            foreach(var i in sp.Phanloaisps)
            {
                _productRepository.DetetePhanLoai(i);
            }
            await _productRepository.DeleteProduct(id);
        }

        public async Task<List<SanPhamDTO>> GetProductByIdDanhMuc(int id)
        {
            var kq = await _productRepository.getSanPhambyDanhMuc(id);
            var result = kq.Select(sp => new SanPhamDTO
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                SoLuong = sp.SoLuong,
                SoLuongBan = sp.SoLuongBan,
                PhanLoais = sp.Phanloaisps.Select(pl => new PhanLoaiDTO
                {
                    IdPl = pl.IdPl,
                    TenPl = pl.TenPl,
                    GiaTien = pl.GiaTien
                }).ToList()
            }).ToList();
            return result;
        }

        public async Task<List<HinhAnhDTO>> GetHinhAnhByIdSp(int id)
        {
            var result = await _hinhAnhRepository.GetHinhAnhByIdSp(id);
            var kq = result.Select(ha => new HinhAnhDTO
            {
                IdImg = ha.IdImg,
                ImgAnh = ha.ImgAnh,
                MaSp = ha.MaSp
            }).ToList();
            return kq;
        }
    }
}
