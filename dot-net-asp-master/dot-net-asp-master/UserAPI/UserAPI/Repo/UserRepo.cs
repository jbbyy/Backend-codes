using UserAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace UserAPI.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DataContext u;
        public UserRepo(DataContext u)
        {
            this.u = u;
        }
        //injection dependency -> need to resolve in programs once again 
        public int Addusers(Users x)
        {
            u.Cust.Add(x);
            return u.SaveChanges();
            //using user model

        }

        public bool Login(string username, string password)
        {
            return u.Cust.Any(x => x.Username == username && x.Password == password);
            //using any method, if exist = true, if not false
            //will use cred model for this function. 
        }

        //public int Deleteusers(int id)
        //{
        //    var p = u.Cust.Where(x => x.UserId == id).FirstOrDefault();
        //    if(p != null)
        //    {
        //        u.Cust.Remove(p);
        //        return u.SaveChanges();
        //    }
        //    return 0;

        //}

        //public Users GetUser(int id)
        //{
        //    var p = u.Cust.Where(x => x.UserId == id).FirstOrDefault();
        //    return p;

        //}

        //public List<Users> GetUsers()
        //{
        //    return u.Cust.ToList();
        //}

        //public int Updateusers(int id, Users x)
        //{
        //    var p = u.Cust.Where(x => x.UserId == id).FirstOrDefault();
        //    if (p != null)
        //    {
        //        p.UserId = x.UserId;
        //        p.FirstName = x.FirstName;
        //        p.LastName = x.LastName;
        //        p.Email = x.Email;
        //        p.Age = x.Age;

        //        u.Entry<Users>(p).State = EntityState.Modified;

        //    }
        //    return 0;
    
    }
}
