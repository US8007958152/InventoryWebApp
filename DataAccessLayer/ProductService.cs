using InventoryWebApp.BusinessLogicLayer;
using InventoryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebApp.DataAccessLayer
{
    public class ProductService : IProduct
    {
        private ProductDbContext context;
        private DbSet<Product> productEntity;
        public ProductService(ProductDbContext context)
        {
            this.context = context;
            productEntity = context.Set<Product>();
        }
        public void Create(Product product)
        {
            context.Entry(product).State = EntityState.Added;
            context.SaveChanges();
           
        }

        public void Delete(int productId)
        {
            Product product = productEntity.Find(productId);
            context.Entry(product).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return productEntity.SingleOrDefault(x => x.ProductNo == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productEntity.AsEnumerable();
        }

        public void Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
