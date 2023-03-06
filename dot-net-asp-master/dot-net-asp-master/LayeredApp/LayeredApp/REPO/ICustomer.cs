using LayeredApp.Model;
namespace LayeredApp.REPO

{
    public interface ICustomer
    {
        List<Customer> GetCustomer();
     
        Customer GetCustomer(int id);
        //get object user based on ID
        int AddCustomers(Customer x);
        int UpdateCustomer(int id, Customer x);
        int DeleteCustomer(int id);
    }
}
