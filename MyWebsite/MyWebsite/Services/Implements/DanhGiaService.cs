using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Services.Implements
{
    public class DanhGiaService : IDanhGiaService
    {
        private readonly IDanhGiaRepository _repository;
        public DanhGiaService(IDanhGiaRepository repo) 
        { 
            _repository = repo;
        }
        public async Task AddDanhGia(DanhGiaRequest danhgia)
        {
            Danhgium m = new Danhgium
            {
                MaSp = danhgia.MaSp,
                MaKh = danhgia.MaKh,
                Content = danhgia.Content
            };
            await _repository.AddDanhGia(m);
        }

        public async Task DeleteDanhGia(int id)
        {
            await _repository.DeleteDanhGia(id);
        }

        public async Task<List<DanhGiaDTO>> GetByIdProductService(int id)
        {
            var kq=await _repository.GetByIdProduct(id);
            var result=kq.Select(dg=> new DanhGiaDTO
            {
                Id = dg.Id,
                MaKh=dg.MaKh,
                MaSp=dg.MaSp,
                Content=dg.Content
            }).ToList();
            return result;
        }

        public async Task UpdateDanhGia(int id, DanhGiaRequest danhgia)
        {
            var kq=await _repository.GetDanhGiaById(id);
            kq.Content = danhgia.Content;
            await _repository.UpdateDanhGia(id, kq);
        }
    }
}
