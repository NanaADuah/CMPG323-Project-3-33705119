using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SuperStoreContext context) : base(context)
        {
            
        }

        public Product GetProductByI(int? id)
        {
            return GetAll().FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public void AddProduct(Product entity)
        {
            Add(entity);
        }

        public void RemoveProduct(Product entity)
        {
            Remove(entity);
        }

        public void UpdateProduct(Product entity)
        {
            Update(entity);
        }
    }
}
