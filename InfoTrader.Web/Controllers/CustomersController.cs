using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTrader.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrader.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{customer_id}", Name = "Get")]
        public async Task<IActionResult> Get(int customerId)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return new NotFoundResult();
            }
            return new ObjectResult(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _customerRepository.GetAllAsync());
        }
    }
}