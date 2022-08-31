using AFI.Core.DomainModel;
using AFI.Core.Services;
using System;
using System.Linq;
using Xunit;

namespace AFI.Core.Tests
{
    public class CustomerRepositoryTests
    {
        private ICustomerRepository _customerRepository;
        private Customer _customer;

        public CustomerRepositoryTests()
        {
            _customerRepository = new CustomerRepositoryFlatFile();
        }

        [Fact]
        public void ShoudSaveCustomer()
        {
            _customer = new Customer() { FirstName = "James", LastName = "Brooker", DOB = DateTime.Now, Email = "james.b@example.com" };

            int newlyRegisteredCustomer = _customerRepository.RegisterCustomer(_customer);

            Assert.NotEqual(0, newlyRegisteredCustomer);

            //can validate other fields as well
        }

        [Fact]
        public void ShoudRetrieveCustomer()
        {
            var existingRegisteredCustomer = new Customer();

            var registeredCustomer = _customerRepository.GetRegisteredCustomers().ToList();

            //used it in simple format, can be used to check it against full object
            Assert.Contains("A", registeredCustomer.Select(x => x.FirstName));
        }
    }
}