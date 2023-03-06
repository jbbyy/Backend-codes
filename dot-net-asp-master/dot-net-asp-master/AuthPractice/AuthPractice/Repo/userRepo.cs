using AuthPractice.Model;

namespace AuthPractice.Repo
{
    public class userRepo : IuserRepo
    {
        private readonly DataContext db;
        public userRepo(DataContext db)
        {
            this.db = db;
        }
        public bool loginUser(Cred c)
        {
           return db.user.Any(x=> x.email == c.email && x.password == c.password);
            //any will return a boolean result based if it fufils conditions 

        }

        public int registerUser(Users u)
        {
            db.user.Add(u);
            
            return db.SaveChanges();
            //will return number of state entities changed in db eg: number of rows affected
            //if added, will return 1 row. If not, return 0
        }
    }
}
