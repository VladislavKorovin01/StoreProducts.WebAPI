using Microsoft.AspNetCore.Mvc;
using StoreProducts.WebAPI.DTOs;
using StoreProducts.WebAPI.Services.Interfaces;

namespace StoreProducts.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService ProductService)
        {
            productService = ProductService;
        }
        [HttpGet]
        public IEnumerable<ProductDTO> Index()
        {
            var products = productService.GetProducts().ToArray();
            return products;
        }
        [HttpGet("{id}")]
        public ProductDTO GetProduct(int id)
        {
            return productService.GetById(id);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDTO product)
        {
            try
            {
                productService.Add(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Update([FromBody]ProductDTO product)
        {
            try
            {
                productService.Update(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
