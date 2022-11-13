using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        public static List<CustomerDto> customers = new List<CustomerDto>  
            {
                new CustomerDto
                {
                Id = 1,
                FirstName = "Janusz",
                LastName = "Kowalski",
                DateOfBirth = "1991-10-21"
                },
                new CustomerDto
                {
                Id = 2,
                FirstName = "Sebix",
                LastName = "Kaczynski",
                DateOfBirth = "2010-10-21"
                }
            };

        // BUG RETURNS ONLY FIRST CUSTOMER
        [HttpGet("GetCustomers")]
        public ActionResult<List<CustomerDto>> Get()
        {
            return Ok(customers[0]);
        }

        [HttpGet("GetCustomer/{id}")]
        public ActionResult<CustomerDto> GetById(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound($"Customer with id: {id} not found!");
            }
            return customer;
        }

        [HttpPost("CreateCustomer")]
        public ActionResult<List<CustomerDto>> Create(CustomerDto customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }

        // BUG NOT UPDATING LAST NAME OF CUSTOMER
        [HttpPut("UpdateCustomer")]
        public ActionResult<List<CustomerDto>> Update(CustomerDto request)
        {
            var customer = customers.Find(c => c.Id == request.Id);
            if (customer == null)
            {
                return NotFound($"Customer with id: {request.Id} not found!");
            }
            customer.FirstName = request.FirstName;
            customer.DateOfBirth = request.DateOfBirth;

            return Ok(customers);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public ActionResult<List<CustomerDto>> Delete(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound($"Customer with id: {id} not found!");
            }
            customers.Remove(customer);
            return Ok(customers);
        }
    }
}
