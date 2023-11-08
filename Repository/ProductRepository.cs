using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeApostas.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly ApostasDBContext _context;
        public ProductRepository(ApostasDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.products.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _context.products.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task PostProductAsync(Product product)
        {
            await _context.products.AddAsync(product);
        }
        public void DeleteProduct(int Id)
        {
            var produto = _context.products.Find(Id);

            if (produto != null)
            {
                _context.products.Remove(produto);
            }

        }

        public void UpdateProduct(Product product)
        {
            _context.products.Entry(product).State = EntityState.Modified;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
