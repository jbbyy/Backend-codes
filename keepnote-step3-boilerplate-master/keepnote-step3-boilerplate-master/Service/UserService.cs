using DAL;
using Entities;
using Exceptions;

namespace Service
{
    /*
  * Service classes are used here to implement additional business logic/validation
  * */
    public class UserService : IUserService
    {
        /*
       Use constructor Injection to inject all required dependencies.
       */
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        //This method should be used to delete an existing user. 
        public bool DeleteUser(string userId)
        {
            var x = repository.GetUserById(userId);
            if (x != null)
            {
                return repository.DeleteUser(userId);
            }
            else
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }

        //This method should be used to get a user by userId.
        public User GetUserById(string userId)
        {
          var x = repository.GetUserById(userId);
            if (x == null)
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
            return x;
        }

        //This method should be used to save a new user.
        public bool RegisterUser(User user)
        {
            var x =  repository.RegisterUser(user);
             if (x == false)
            {
                throw new UserAlreadyExistException($"This userid: {user.UserId} already exists");
            }
            return x;
        }

        //This method should be used to update an existing user.
        public bool UpdateUser(string userId, User user)
        {
            var x = repository.UpdateUser(user);
            if (x == false)
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
            return x;
        }

        //This method should be used to validate a user using userId and password.
        public bool ValidateUser(string userId, string password)
        {
            var x =  repository.ValidateUser(userId, password);
            if (x == false)
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
            return x;
        }
    }
}
