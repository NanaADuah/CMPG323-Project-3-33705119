using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrderRepository : GenericRepository<OrderDetail>, IOrderRepository
    {
        public OrderRepository(SuperStoreContext context) : base(context)
        {
        }

        public IEnumerable<OrderDetail> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
