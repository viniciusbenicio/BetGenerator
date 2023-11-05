using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpPost]
        public Product PostProducts([FromBody] Product product, [FromServices] ApostasDBContext _context)
        {
            var produto = new Product()
            {
                Name = product.Name
            };

            _context.products.Add(produto);
            _context.SaveChanges();

            return produto;

        }

        [HttpGet]
        public Product GetProducts([FromServices] ApostasDBContext context)
        {
            return context.products.FirstOrDefault();

        }

    }
}
