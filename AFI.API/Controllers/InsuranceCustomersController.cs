using AFI.API.Enums;
using AFI.API.Models;
using AFI.API.Util;
using AFI.Core.DomainModel;
using AFI.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AFI.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("v1/[controller]")]
    public class InsuranceCustomersController : AFIAPIControllerBase
    {
        private readonly ILogger<InsuranceCustomersController> _logger;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public InsuranceCustomersController(ILogger<InsuranceCustomersController> logger, IMapper mapper, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult GetInsuranceCustomers()
        {
            try
            {
                return Ok(_customerRepository.GetRegisteredCustomers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while retrieving custmoers, Error: {ex}");
                return AFIAPIErrorResponse(StatusCodes.Status500InternalServerError.ToString(), ApiErrorSubCode.GenericError, GlobalVariables.GenericMessage);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("{id}", Name = "GetInsuranceCustomer")]
        public IActionResult GetInsuranceCustomers(int id)
        {
            try
            {
                return Ok(_customerRepository.GetRegisteredCustomerById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while retrieving custmoer: {id}, Error: {ex}");
                return AFIAPIErrorResponse(StatusCodes.Status500InternalServerError.ToString(), ApiErrorSubCode.GenericError, GlobalVariables.GenericMessage);
            }
        }

        /// <summary>
        /// Registers the customer into AFI Customer Portal
        /// </summary>
        /// <param name="customerRegistraionDTO"></param>
        /// <returns></returns>
        /// <response code="201">Returns newly registered customer's id</response>
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(APIErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult AddInsuranceCustomers([FromBody] CustomerRegistrationDTO customerRegistraionDTO)
        {
            try
            {
                _logger.LogInformation($"Trying to register new customer: {customerRegistraionDTO.PolicyHolderFirstName}");
                var registeredCustomerId = _customerRepository.RegisterCustomer(_mapper.Map<Customer>(customerRegistraionDTO));
                var newlyRegisteredCustomer = _customerRepository.GetRegisteredCustomerById(registeredCustomerId);
                return CreatedAtRoute("GetInsuranceCustomer", new { id = registeredCustomerId }, newlyRegisteredCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception while registering custmoer {ex}");
                return AFIAPIErrorResponse(StatusCodes.Status500InternalServerError.ToString(), ApiErrorSubCode.GenericError, GlobalVariables.GenericMessage);
            }
        }
    }
}