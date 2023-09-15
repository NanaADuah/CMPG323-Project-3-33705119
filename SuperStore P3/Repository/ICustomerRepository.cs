using Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository<T> where T: class
    {
        Customer GetAllCustomers();
    }
}
