namespace CustomerAPI.DALService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        void UpdateCustomer(int id, Customer customer);
    }
}
