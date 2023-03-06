using System;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    //Repository class is used to implement all Data access operations
    public class UserRepository : IUserRepository
    {
        private readonly KeepDbContext dbContext;
        public UserRepository(KeepDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var p = dbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            dbContext.Users.Remove(p);
            var y = dbContext.SaveChanges();
            return (y == 1);
        }
        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
            var p = dbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            return p;
        }
        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            dbContext.Users.Add(user);
            int y = dbContext.SaveChanges();
            return (y == 1);
        }
        //This method should be used to update an existing user.
        public bool UpdateUser(User user)
        {
            var a = dbContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (a != null)
            {
                a.UserName = user.UserName;
                a.UserId = user.UserId;
                a.Password = user.Password;
                a.Contact = user.Contact;
                a.CreatedAt = user.CreatedAt;
                dbContext.Entry<User>(a).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            var p = dbContext.Users.Where(x => x.UserId == userId && x.Password == password).FirstOrDefault();
            if (p != null)
            {
                return true;
            }
            return false;
        }
    }
}
