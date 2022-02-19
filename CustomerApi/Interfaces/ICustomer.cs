using CustomerApi.Model;

namespace CustomerApi.Interfaces
{
    public interface ICustomer
    {
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task UpdateCustomer (Customer customer);
        Task<Customer> GetCustomerByName(string name);
        Task GetAllCustomers();        
    }
}
