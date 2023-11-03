using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestAPI.Models;
using TechTestAPI.Services.ProductService;

namespace TechTestAPI.Controllers
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
        public async Task<ActionResult<List<Product>>> GetAll() 
        { 
            return await _productService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Add(Product product)
        {
            var result = await _productService.Add(product);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> Update(int id, [FromBody] Product request)
        {
            var result = await _productService.Update(id, request);

            if (result == null)
                return NotFound("Sorry, but the id doesn't exist");

            return Ok(result);
        }
    }
}
