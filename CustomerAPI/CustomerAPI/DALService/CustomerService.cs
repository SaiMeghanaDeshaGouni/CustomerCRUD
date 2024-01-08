namespace CustomerAPI.DALService
{
    public class CustomerService: ICustomerService
    {
        private List<Customer> _customers;
        private readonly CustomerContext _context;

        public CustomerService()
        {
            _customers = new List<Customer>
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
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(c => c.id == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            // Assign a new ID (in a real scenario, you might want to handle ID generation differently)
            customer.id = _customers.Max(c => c.id) + 1;
            customer.created = DateTime.Now;
            customer.lastUpdated = DateTime.Now;

            _customers.Add(customer);

            return customer;
        }

        public void UpdateCustomer(int id, Customer updatedCustomer)
        {
           
                var existingCustomer = _customers.Find(c => c.id == id);

                if (existingCustomer == null)
                {
                    throw new ArgumentNullException(nameof(updatedCustomer));
                }

                existingCustomer.firstName = updatedCustomer.firstName;
                existingCustomer.lastName = updatedCustomer.lastName;
                existingCustomer.email = updatedCustomer.email;
                existingCustomer.lastUpdated = DateTime.UtcNow;
            }
           
        }       
    }
