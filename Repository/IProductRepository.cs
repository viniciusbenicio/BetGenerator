using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeApostas.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Task<Product> GetProductByIdAsync(int Id);
        Task PostProductAsync(Product product);
        void DeleteProduct(int Id);
        void UpdateProduct(Product product);
        Task SaveAsync();
    }
}
