using MyWebsite.Models.DTOs;
using MyWebsite.Models.Entities;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Interfaces;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Services.Implements
{
    public class KhachHangService : IKhachHangService
    {
        private readonly IKhachHangRepository _khachHangRepository;
        private readonly IGioHangRepository _gioHangRepository;
        public KhachHangService(IKhachHangRepository khachHangRepo, IGioHangRepository gioHangRepository)
        {
            _khachHangRepository = khachHangRepo;
            _gioHangRepository = gioHangRepository;
        }

        public async Task AddKhachHang(KhachHangRequest hangDTO)
        {
            Khachhang kh = new Khachhang
            {
                HoTen = hangDTO.HoTen,
                Email = hangDTO.Email,
                Tk=hangDTO.Tk,
                Mk = hangDTO.Mk,
                ImgAvarta = hangDTO.ImgAvarta,
                DiaChi = hangDTO.DiaChi,
                Sdt = hangDTO.Sdt
            };
            await _khachHangRepository.AddKhachHang(kh);
            if (kh.Tk != null && kh.Mk != null)
            {
                var kq = await _khachHangRepository.GetByTk(kh.Tk, kh.Mk);
                await _gioHangRepository.AddGioHang(kq.MaKh);
            }
        }

        public async Task DeleteKhachHang(int id)
        {
            await _khachHangRepository.DeleteKhachHang(id);
        }

        public async Task<List<KhachHangDTO>> GetAll()
        {
            var kq=await _khachHangRepository.GetAll();
            var result=kq.Select(kh=>new KhachHangDTO
            {
                MaKh=kh.MaKh,
                HoTen=kh.HoTen,
                Email=kh.Email,
                Tk=kh.Tk,
                Mk=kh.Mk,
                ImgAvarta=kh.ImgAvarta,
                DiaChi=kh.DiaChi,
                Sdt=kh.Sdt
            }).ToList();
            return result;
        }

        public async Task<KhachHangDTO> GetKhachHang(int id)
        {
            if (id != 0)
            {
                var result = await _khachHangRepository.GetById(id);
                var kq = new KhachHangDTO
                {
                    MaKh = result.MaKh,
                    HoTen = result.HoTen,
                    Email = result.Email,
                    Tk = result.Tk,
                    Mk = result.Mk,
                    ImgAvarta = result.ImgAvarta,
                    DiaChi = result.DiaChi,
                    Sdt = result.Sdt
                };
                return kq;
            }
            throw new Exception("Khong thay khach hang");
        }

        public async Task UpdateKhachHang(int id, KhachHangRequest khachhangDTO)
        {
            Khachhang a = new Khachhang
            {
                MaKh=id,
                HoTen=khachhangDTO.HoTen,
                Email=khachhangDTO.Email,
                Mk = khachhangDTO.Mk,
                ImgAvarta=khachhangDTO.ImgAvarta,
                DiaChi=khachhangDTO.DiaChi,
                Sdt=khachhangDTO.Sdt
            };
            await _khachHangRepository.UpdateKhachHang(a);
        }
    }
}
