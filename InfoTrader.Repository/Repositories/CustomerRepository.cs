using InfoTrader.Domain.Context;
using InfoTrader.Domain.Interfaces;
using InfoTrader.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrader.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context;
        }

        public async Task Create(Customer customer)
        {
            await _context.Customers.InsertOneAsync(customer);
        }

        public async Task<bool> Delete(int customerId)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(c => c.CustomerId, customerId);
            DeleteResult deleteResult = await _context.Customers.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Find(customer => true).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq(c => c.CustomerId, customerId);
            return await _context.Customers.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Customer newCustomer)
        {
            ReplaceOneResult updateResult = await _context.Customers.ReplaceOneAsync(
                filter: c=>c.CustomerId == newCustomer.CustomerId,
                replacement: newCustomer);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
