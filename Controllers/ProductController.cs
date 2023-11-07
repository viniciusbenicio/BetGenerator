using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using GeradorDeApostas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
       

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        [HttpGet("Id")]
        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            return product;
        }


        [HttpPost]
        public void PostProducts([FromBody] Product product)
        {
            _productRepository.PostProduct(product);

            _productRepository.Save();

        }

        [HttpPut("Id")]
        public Product PutProduct([FromBody] Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.Save();

            return product;
        }

        [HttpDelete("Id")]
        public void DeleteProductById(int id)
        {
            _productRepository.DeleteProduct(id);
            _productRepository.Save();  
        }
    }
}
