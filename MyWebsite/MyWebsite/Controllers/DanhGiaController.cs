using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models.Requests;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiaController : ControllerBase
    {
        private readonly IDanhGiaService _service;
        public DanhGiaController(IDanhGiaService se)
        {
            _service = se;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var kq=await _service.GetByIdProductService(id);
            return Ok(kq);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDanhGia(int id, DanhGiaRequest requests)
        {
            await _service.UpdateDanhGia(id, requests);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddDanhGia(DanhGiaRequest danhgia)
        {
            await _service.AddDanhGia(danhgia);
            return Ok();
        }
    }
}
