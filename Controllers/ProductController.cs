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
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        [HttpGet("v1/products/{id}")]
        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            return product;
        }


        [HttpPost("v1/products")]
        public void PostProducts([FromBody] Product product)
        {
            _productRepository.PostProduct(product);

            _productRepository.Save();

        }

        [HttpPut("v1/products/{id}")]
        public Product PutProduct([FromBody] Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.Save();

            return product;
        }

        [HttpDelete("v1/products/{id}")]
        public void DeleteProductById(int id)
        {
            _productRepository.DeleteProduct(id);
            _productRepository.Save();  
        }
    }
}
