using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models.Requests;
using MyWebsite.Services.Interfaces;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly IDanhMucService _service;
        public DanhMucController(IDanhMucService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            return Ok(await _service.GetAllDanhMuc());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            return Ok(await _service.GetDMById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDM(DanhMucRequest request)
        {
            await _service.AddDanhMuc(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDM(int id, DanhMucRequest request)
        {
            await _service.UpdateDanhMuc(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDM(int id)
        {
            await _service.DeleteDanhMuc(id);
            return Ok();
        }
    }
}
