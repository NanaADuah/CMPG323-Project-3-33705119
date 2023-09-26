using Data;
using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {

        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
        }

        public OrderDetail GetOrderDetailByI(int? id)
        {
            return GetAll().FirstOrDefault(x => x.OrderDetailsId == id);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails()
        {
            return GetAll().ToList();
        }

        public void AddOrderDetail(OrderDetail entity)
        {
            Add(entity);
        }

        public void RemoveOrderDetail(OrderDetail entity)
        {
            Remove(entity);
        }

        public void UpdateOrderDetail(OrderDetail entity)
        {
            Update(entity);
        }

    }
}
