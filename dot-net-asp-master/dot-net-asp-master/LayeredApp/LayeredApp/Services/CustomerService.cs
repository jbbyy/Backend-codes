using LayeredApp.Model;
using LayeredApp.REPO;
using LayeredApp.Exceptions;

namespace LayeredApp.Services
{
    public class CustomerService : ICustService
    {
        private readonly ICustomer repo;

        public CustomerService(ICustomer repo)
        {
            this.repo = repo;
        }

        public int AddCustomers(Customer x)
        {
           if(repo.GetCustomer(x.CustomerId) != null)
            {
                throw new CustAlreadyExistException($"Customer with id:{x.CustomerId} already exisit");
            }
           return repo.AddCustomers(x);
        }

        public int DeleteCustomer(int id)
        {
            if (repo.GetCustomer(id) != null)
            {
                throw new CustNotFoundException ($"Customer with id:{id} does not exist");
            }
            return repo.DeleteCustomer(id);
        }

        public List<Customer> GetCustomer()
        {
            return repo.GetCustomer();
        }

        public Customer GetCustomer(int id)
        {
            var res = repo.GetCustomer(id);
            if (res == null)
            {
                throw new CustNotFoundException($"Customer with id:{id} does not exist");
            }
            return res;
        }

        public int UpdateCustomer(int id, Customer x)
        {
            if (repo.GetCustomer(id) == null)
            {
                throw new CustNotFoundException($"Customer with id:{id} does not exist");
            }
            return repo.UpdateCustomer(id, x);
        }
    }
}
