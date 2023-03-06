using LayeredApp.Model;
using Microsoft.EntityFrameworkCore;
using static LayeredApp.REPO.CustomerRep;

namespace LayeredApp.REPO
{
    public class CustomerRep :ICustomer
    {
   
            private readonly DataContext u;
            public CustomerRep(DataContext u)
            {
                this.u = u;
            }



            public int AddCustomers(Customer x)
            {
                u.Cust.Add(x);
                return u.SaveChanges();

            }

            public int DeleteCustomer(int id)
            {
                var p = u.Cust.Where(x => x.CustomerId == id).FirstOrDefault();
            
                 u.Cust.Remove(p);
                 return u.SaveChanges();
               

            }

            public Customer GetCustomer(int id)
            {
                var p = u.Cust.Where(x => x.CustomerId == id).FirstOrDefault();
                return p;

            }

            public List<Customer> GetCustomer()
            {
                return u.Cust.ToList();
            }

            public int UpdateCustomer(int id, Customer x)
            {
                var p = u.Cust.Where(x => x.CustomerId == id).FirstOrDefault();

            p.CustomerId = x.CustomerId;
            p.FirstName = x.FirstName;
            p.LastName = x.LastName;
            p.Age = x.Age;
            p.Email = x.Email;

            u.Entry<Customer>(p).State = EntityState.Modified;
             return u.SaveChanges();
        }
    }
}
