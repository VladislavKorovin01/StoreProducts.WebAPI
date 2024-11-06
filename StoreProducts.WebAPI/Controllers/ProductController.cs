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
                if (ModelState.IsValid)
                {
                    productService.Add(product);
                    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
                }
                else
                {
                    return BadRequest();
                }

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
                var product = productService.GetById(id);
                if(product != null)
                {
                    productService.Delete(id);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody]ProductDTO product)
        {
            try
            {
                var putProduct = productService.GetById(product.Id);
                if (putProduct != null)
                {
                    productService.Update(product);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
