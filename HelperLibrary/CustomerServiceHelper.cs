using DAO;
using Entity;

namespace HelperLibrary
{
    public class CustomerServiceHelper
    {
        CustomerService customerService = null;

        public CustomerServiceHelper()
        {
            customerService = new CustomerService();
        }

        public Customer getCustomerByID(int id)
        {
            return customerService.GetCustomerById(id);
        }

        public Customer getCustomerByUsername(string username)
        {
            return customerService.GetCustomerByUsername(username);
        }

        public bool registerCustomer(Customer customer)
        {
            return customerService.RegisterCustomer(customer);
        }

        public bool updateCustomer(int customerId, Customer customer)
        {
            return customerService.UpdateCustomer(customerId, customer);
        }

        public bool deleteCustomer(int customerId)
        {
            return customerService.DeleteCustomer(customerId);
        }

        public List<Customer> getAllCustomers()
        {
            return customerService.GetAllCustomers();
        }
    }
}
