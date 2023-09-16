using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public Order GetAllOrders()
        {
            return _context.Orders.OrderBy(order => order.OrderId).FirstOrDefault();
        }
    }
}
