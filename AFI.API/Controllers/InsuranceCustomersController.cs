using AFI.API.Models;
using AFI.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFI.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class InsuranceCustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public InsuranceCustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [HttpGet]
        public IActionResult GetInsuranceCustomers()
        {
            return Ok(_customerRepository.GetRegisteredCustomers());
        }

        [HttpGet("{id}", Name = "GetInsuranceCustomer")]
        public IActionResult GetInsuranceCustomers(int id)
        {
            return Ok(_customerRepository.GetRegisteredCustomerById(id));
        }

        [HttpPost]
        public IActionResult AddInsuranceCustomers([FromBody] CustomerRegistrationDTO customerRegistraionDTO)
        {
            Customer newlyRegisteredCustomer = new Customer();
            return CreatedAtRoute("GetInsuranceCustomer", new { id = newlyRegisteredCustomer.CustomerID }, newlyRegisteredCustomer);
        }
    }
}