using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return GetAll().ToList();
            }
            catch
            {

                throw new NotImplementedException();
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            Remove(customer);
        }
    }
}
