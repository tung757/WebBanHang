using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models.DTOs;
using MyWebsite.Models.Requests;
using MyWebsite.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace MyWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.Getallproduct());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyidd(int id)
        {
            try
            {
                var result = await _productService.FindbyID(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Addproduct(SanPhamRequest product)
        {
            try
            {
                await _productService.AddProductService(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return Ok(product);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, SanPhamRequest product)
        {
            try
            {
                await _productService.UpdateProductService(id, product);
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductService(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return Ok(id);
        }

        [HttpGet("byiddm{iddm}")]
        public async Task<IActionResult> GetProductByDM(int iddm)
        {
            var result = await _productService.GetProductByIdDanhMuc(iddm);
            return Ok(result);
        }
    }
}
