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

        [HttpPost]
        public void PostProducts([FromBody] Product product)
        {
            _productRepository.PostProduct(product);

            _productRepository.Save();

        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

    }
}
