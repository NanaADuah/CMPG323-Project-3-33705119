using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllOrders();
    }
}
