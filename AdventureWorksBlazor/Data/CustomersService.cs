using AdventureWorksBlazor.Pages;
using AdventureWorksNS.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksBlazor.Data
{
    public class CustomersService : ICustomersService
    {
        private readonly AdventureWorksDB db;

        public CustomersService(AdventureWorksDB db)
        {
            this.db = db;
        }
        public Task<List<Customer>> GetCustomersAsync()
        {
            return db.Customers.ToListAsync();

        }
        public Task<List<Customer>> GetCustomersAsync(string CompanyName)
        {
            return db.Customers.Where(c => c.CompanyName == CompanyName).ToListAsync();

        }
        public Task<Customer?> GetCustomerAsync(int id)
        {
            return db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);

        }
        public Task<Customer> CreateCustomerAsync(Customer c)
        {
            c.CustomerId = 0;
            c.PasswordHash = "vacio";
            c.PasswordSalt = "vacio";
            db.Customers.Add(c);
            db.SaveChanges();
            return Task.FromResult(c);
        }
        public Task<Customer> UpdateCustomerAsync(Customer c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChangesAsync();
            return Task.FromResult(c);
        }
        public Task DeleteCustomerAsync(int id)
        {
            Customer? customer = db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id)?.Result;

            if (customer == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                db.Customers.Remove(customer);
                return db.SaveChangesAsync();
            }
        }

    }
}
