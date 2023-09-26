using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext superStoreContext) : base(superStoreContext)
        {
        }

        public Customer GetCustomerByI(int? id)
        {
            return GetAll().FirstOrDefault(x => x.CustomerId == id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll().ToList();
        }

        public void AddCustomer(Customer entity)
        {
            Add(entity);
        }

        public void RemoveCustomer(Customer entity)
        {
            Remove(entity);
        }
        
        public void UpdateCustomer(Customer entity)
        {
            Update(entity);
        }
    }
}
