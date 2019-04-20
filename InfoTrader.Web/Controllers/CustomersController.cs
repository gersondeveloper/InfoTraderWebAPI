using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using InfoTrader.Domain.Interfaces;
using InfoTrader.Domain.Models;
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
        public async Task<IActionResult> Get(int customer_id)
        {
            var customer = await _customerRepository.GetCustomerById(customer_id);
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var _validator = new CustomerValidator();
            var _customer = new Customer();
            var result = _validator.Validate(customer);

            if (ModelState.IsValid)
            {
                await _customerRepository.Create(customer);
                return new OkResult();
            }

            return new BadRequestObjectResult(result);
        }
    }
}