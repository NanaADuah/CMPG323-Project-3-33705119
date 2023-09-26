using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductByI(int? id);
        void AddProduct(Product entity);
        void RemoveProduct(Product entity);
        void UpdateProduct(Product entity);
    }
}
