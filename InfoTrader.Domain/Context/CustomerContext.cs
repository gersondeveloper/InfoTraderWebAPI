using System;
using System.Collections.Generic;
using System.Text;
using InfoTrader.Domain.Interfaces;
using InfoTrader.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace InfoTrader.Domain.Context
{
    public class CustomerContext : ICustomerContext
    {
        private readonly IMongoDatabase _db;

        public CustomerContext(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("InfoTraderDB"));
            _db = client.GetDatabase("InfoTrader");
        }

        public IMongoCollection<Customer> Customers => _db.GetCollection<Customer>("Customers");
    }
}
