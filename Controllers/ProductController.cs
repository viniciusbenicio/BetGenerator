using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using GeradorDeApostas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet("v1/products")]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            return Ok(products);
        }

        [HttpGet("v1/products/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            return Ok(product);
        }


        [HttpPost("v1/products")]
        public async Task<IActionResult> PostProductsAsync([FromBody] Product product)
        {
            await _productRepository.PostProductAsync(product);

            await _productRepository.SaveAsync();

            return Ok(product);

        }

        [HttpPut("v1/products/{id}")]
        public Product PutProduct([FromBody] Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.SaveAsync();

            return product;
        }

        [HttpDelete("v1/products/{id}")]
        public void DeleteProductById(int id)
        {
            _productRepository.DeleteProduct(id);
            _productRepository.SaveAsync();
        }
    }
}
