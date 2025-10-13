using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models.Requests;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _khachHangService;
        public KhachHangController(IKhachHangService khachhangservice) { 
            _khachHangService = khachhangservice;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var kq=await _khachHangService.GetKhachHang(id);
                return Ok(kq);
            }
            catch (Exception ex) { 
                return BadRequest(new {message=ex.Message});
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllKH() {
            var result = await _khachHangService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddKhachHang(KhachHangRequest re)
        {
            try
            {
                await _khachHangService.AddKhachHang(re);
                return Ok(re);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKhachHang(int id, KhachHangRequest re)
        {
            try
            {
                await _khachHangService.UpdateKhachHang(id, re);
                return Ok(id);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKhachHang(int id)
        {
            try
            {
                await _khachHangService.DeleteKhachHang(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
