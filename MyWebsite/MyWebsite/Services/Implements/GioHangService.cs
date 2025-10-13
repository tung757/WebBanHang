using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Services.Implements
{
    public class GioHangService : IGioHangService
    {
        private readonly IGioHangRepository _repository;
        private readonly IGioHangItemRepository _itemRepository;
        public GioHangService(IGioHangRepository repository, IGioHangItemRepository items) { 
            _repository = repository;
            _itemRepository = items;
        }

        public async Task AddItemGioHang(GioHangSanPhamRequest request)
        {
            GiohangSanpham newItem = new GiohangSanpham
            {
                IdGh=request.IdGh,
                MaSp=request.MaSp,
                SoLuong=request.SoLuong
            };
            await _itemRepository.AddItemGioHang(newItem);
        }

        public async Task DeleteItemGioHang(GioHangSanPhamRequest request)
        {
            await _itemRepository.RemoveItemGioHang(request.IdGh, request.MaSp);
        }

        public async Task<List<GioHangSanPhamDTO>> GetGioHangByIdKH(int id)
        {
            var kq = await _repository.GetGiohangByIdKH(id);
            var idgh = kq.IdGh;
            var items_cart = await _itemRepository.GetAllItemsGioHangByIDGioHang(idgh);
            var result = items_cart.Select(item => new GioHangSanPhamDTO
            {
                MaSp = item.MaSp,
                IdGh = idgh,
                SoLuong = item.SoLuong
            }).ToList();
            return result;
        }

        public async Task UpdateItemGioHang(GioHangSanPhamRequest request)
        {
            if(request.IdGh == 0)
            {
                throw new Exception("Khong tim thay item");
            }
            GiohangSanpham ud = new GiohangSanpham
            {
                IdGh = request.IdGh,
                MaSp = request.MaSp,
                SoLuong= request.SoLuong
            };
            await _itemRepository.UpdateItemGioHang(ud);
        }
    }
}
