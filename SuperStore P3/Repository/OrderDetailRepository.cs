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

    }
}
