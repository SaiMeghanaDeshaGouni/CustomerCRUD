namespace CustomerAPI
{
    public class CustomerContext
    {
        public List<Customer> Customers { get; set; }

        public CustomerContext()
        {
            Customers = new List<Customer>();
        }
    }
}
