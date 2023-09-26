using Models; 

namespace EcoPower_Logistics.Repository
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByI(int? id);
        void AddCustomer(Customer entity);
        void RemoveCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
    }
}
