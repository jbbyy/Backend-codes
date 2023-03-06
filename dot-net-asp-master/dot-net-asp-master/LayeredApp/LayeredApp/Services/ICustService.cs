using LayeredApp.Model;

namespace LayeredApp.Services
{
    public interface ICustService
    {
       
            List<Customer> GetCustomer();
            Customer GetCustomer(int id);
            //get object user based on ID
            int AddCustomers(Customer x);
            int UpdateCustomer(int id, Customer x);
            int DeleteCustomer(int id);
        
    }
}
