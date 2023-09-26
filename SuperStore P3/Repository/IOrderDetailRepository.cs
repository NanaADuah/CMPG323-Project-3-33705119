using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailRepository: IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllOrderDetails();
        OrderDetail GetOrderDetailByI(int? id);
        void AddOrderDetail(OrderDetail entity);
        void RemoveOrderDetail(OrderDetail entity);
        void UpdateOrderDetail(OrderDetail entity);
    }
}
