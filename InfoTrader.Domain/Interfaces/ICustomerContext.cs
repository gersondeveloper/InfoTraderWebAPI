using InfoTrader.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrader.Domain.Interfaces
{
    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}
