using InfoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrader.Domain.Services
{
    public interface ICustomerService : IDisposable
    {
        Task<IEnumerable<Customer>> GetAll();
        Task Create(Customer customer);
        Task<Customer> GetCustomerById(int customerId);
        Task<bool> Delete(int customerId);
        Task<bool> Update(Customer newCustomer);
    }
}
