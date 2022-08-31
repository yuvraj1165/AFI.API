using AFI.Core.DomainModel;
using System.Collections.Generic;

namespace AFI.Core.Services
{
    public interface ICustomerRepository
    {
        int RegisterCustomer(Customer customerToRegister);

        Customer GetRegisteredCustomerById(int id);

        IEnumerable<Customer> GetRegisteredCustomers();
    }
}