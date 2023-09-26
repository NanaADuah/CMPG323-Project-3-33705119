using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public Order GetOrderByI(int id)
        {
            return GetAll().FirstOrDefault(x => x.OrderId == id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll().ToList();
        }

        public void AddOrder(Order entity)
        {
            Add(entity);
        }

        public void RemoveOrder(Order entity)
        {
            Remove(entity);
        }

        public void UpdateOrder(Order entity)
        {
            Update(entity);
        }
    }
}
