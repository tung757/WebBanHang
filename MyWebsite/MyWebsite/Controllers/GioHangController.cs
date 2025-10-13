using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models.Requests;
using MyWebsite.Repositories.Implements;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangService _giohangService;
        public GioHangController(IGioHangService service)
        {
            _giohangService = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGioHang(int id)
        {
            try
            {
                var kq = await _giohangService.GetGioHangByIdKH(id);
                return Ok(kq);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItemGioHang(GioHangSanPhamRequest gioHangSanPhamRequest)
        {
            try
            {
                await _giohangService.UpdateItemGioHang(gioHangSanPhamRequest);
                return Ok(gioHangSanPhamRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
