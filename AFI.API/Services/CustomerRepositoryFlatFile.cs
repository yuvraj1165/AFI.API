using AFI.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFI.API.Services
{
    public class CustomerRepositoryFlatFile : ICustomerRepository
    {
        public Customer GetRegisteredCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetRegisteredCustomers()
        {
            throw new NotImplementedException();
        }

        public bool RegisterCustomer(Customer customerToRegister)
        {
            throw new NotImplementedException();
        }
    }
}