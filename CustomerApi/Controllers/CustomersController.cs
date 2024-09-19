using CustomerApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{

    [Produces("application/json")]
    [ApiController]

    public class CustomersController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet("customers/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { Message = $"Customer with ID {id} not found." });
            }
            return Ok(customer);


        }

        [HttpGet("customers/")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);

        }

        [HttpPost("customers")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }
            var createdCustomer = await _customerRepository.AddAsync(customer);
            return Ok(createdCustomer);
        }

        [HttpPut("customers/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("");
            }

            await _customerRepository.UpdateAsync(customer);
            return Ok();

        }

        [HttpDelete("customers/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            
            var result = await _customerRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound(); 
            }

            return Ok(); 
        }

}
}
