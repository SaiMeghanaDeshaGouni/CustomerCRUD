using CustomerAPI.DALService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // this hardcoded data will be replaced with a DBContext in real implementation
        private readonly CustomerContext _context;
        Customer[] customers = new Customer[]
        {
            new Customer { id = 1, firstName = "John", lastName = "Doe", email = "john.doe@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 2, firstName = "Jane", lastName = "Doe", email = "jane.doe@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 3, firstName = "Alice", lastName = "Smith", email = "alice.smith@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 4, firstName = "Bob", lastName = "Johnson", email = "bob.johnson@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 5, firstName = "Eva", lastName = "Williams", email = "eva.williams@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 6, firstName = "David", lastName = "Brown", email = "david.brown@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 7, firstName = "Catherine", lastName = "Miller", email = "catherine.miller@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 8, firstName = "Frank", lastName = "Davis", email = "frank.davis@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 9, firstName = "Grace", lastName = "Garcia", email = "grace.garcia@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 10, firstName = "Harry", lastName = "Jones", email = "harry.jones@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 11, firstName = "Ivy", lastName = "Moore", email = "ivy.moore@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 12, firstName = "James", lastName = "Clark", email = "james.clark@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 13, firstName = "Karen", lastName = "Taylor", email = "karen.taylor@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 14, firstName = "Leonard", lastName = "Hill", email = "leonard.hill@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 15, firstName = "Mia", lastName = "Perez", email = "mia.perez@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 16, firstName = "Nathan", lastName = "Baker", email = "nathan.baker@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 17, firstName = "Olivia", lastName = "King", email = "olivia.king@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 18, firstName = "Peter", lastName = "Fisher", email = "peter.fisher@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 19, firstName = "Quincy", lastName = "Turner", email = "quincy.turner@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
            new Customer { id = 20, firstName = "Rachel", lastName = "Ward", email = "rachel.ward@email.com", created = DateTime.Now, lastUpdated = DateTime.Now },
        };
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }


        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null");
            }

            var addedCustomer = _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.id }, addedCustomer);

        }

        [Route("UpdateCustomer/{id}")]
        [HttpPost]        
        public IActionResult UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if (updatedCustomer == null || id != updatedCustomer.id)
            {
                return BadRequest("Invalid data");
            }

            var existingCustomer = _customerService.GetCustomer(id);

            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.UpdateCustomer(id, updatedCustomer);
            return NoContent();
        }

        private int GetNextCustomerId()
        {
            return _context.Customers.Any() ? _context.Customers.Max(c => c.id) + 1 : 1;
        }
    }
}