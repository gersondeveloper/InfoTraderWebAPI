using InfoTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoTrader.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task Create(Contact contact);
        Task<Contact> GetContactById(int contactId);
        Task<bool> Delete(int contactId);
        Task<bool> Update(Contact newCustomer);
    }
}
