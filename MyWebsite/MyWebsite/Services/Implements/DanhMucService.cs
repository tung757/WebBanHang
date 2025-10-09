

using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Services.Implements
{
    public class DanhMucService : IDanhMucService
    {
        private readonly IDanhMucRepository _repository;
        public DanhMucService(IDanhMucRepository repository)
        {
            _repository = repository;
        }
        public async Task AddDanhMuc(DanhMucRequest request)
        {
            Danhmuc dm = new Danhmuc
            {
                TenDm = request.TenDm,
                ImgDm = request.ImgDm
            };
            await _repository.AddDM(dm);
        }

        public async Task DeleteDanhMuc(int id)
        {
            var kq= await _repository.getDMbyID(id);
            if (kq != null) { 
                await _repository.DeleteDM(id);
            }
            else
            {
                throw new Exception("Không tìm thấy danh mục");
            }
        }

        public async Task<List<DanhMucDTO>> GetAllDanhMuc()
        {
            var kq = await _repository.getAllDM();
            var result = kq.Select(sp => new DanhMucDTO
            {
                MaDm = sp.MaDm,
                TenDm = sp.TenDm,
                ImgDm = sp.ImgDm
            }).ToList();
            return result;
        }

        public async Task<DanhMucDTO> GetDMById(int id)
        {
            var kq= await _repository.getDMbyID(id);
            DanhMucDTO result = new DanhMucDTO
            {
                MaDm = kq.MaDm,
                TenDm = kq.TenDm,
                ImgDm = kq.ImgDm
            };
            return result;
        }

        public async Task UpdateDanhMuc(int id, DanhMucRequest danhMucRequest)
        {
            var kq = await _repository.getDMbyID(id);
            kq.TenDm= danhMucRequest.TenDm;
            kq.ImgDm= danhMucRequest.ImgDm;
            await _repository.UpdateDM(kq);
        }
    }
}
