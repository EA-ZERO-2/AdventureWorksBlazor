using AdventureWorksNS.Data;

namespace AdventureWorksBlazor.Data
{
    public interface ICustomersService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Customer>> GetCustomersAsync(string CompanyName);

        Task<Customer?> GetCustomerAsync(int id);

        Task<Customer> CreateCustomerAsync(Customer c);

        Task<Customer> UpdateCustomerAsync(Customer c);

        Task DeleteCustomerAsync(int id);

    }
}
