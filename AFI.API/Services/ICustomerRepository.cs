using AFI.API.Models;
using System.Collections.Generic;

namespace AFI.API.Services
{
    public interface ICustomerRepository
    {
        bool RegisterCustomer(Customer customerToRegister);

        Customer GetRegisteredCustomerById(int id);

        IEnumerable<Customer> GetRegisteredCustomers();
    }
}