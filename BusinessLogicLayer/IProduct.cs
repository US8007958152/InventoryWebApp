using InventoryWebApp.Models;

namespace InventoryWebApp.BusinessLogicLayer
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        void Create(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
