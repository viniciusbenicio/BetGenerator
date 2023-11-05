using GeradorDeApostas.Models;

namespace GeradorDeApostas.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int Id);
        void PostProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
        void Save();
    }
}
