using AuthPractice.Exceptions;
using AuthPractice.Model;
using AuthPractice.Repo;

namespace AuthPractice.Services
{
    public class UserService : IUserService
    {
        private readonly IuserRepo repo;
        private readonly ITokenGenerator tg;

        public UserService(IuserRepo repo, ITokenGenerator tg)
        {
            this.repo = repo;
            this.tg = tg;
        }
        public bool loginUser(Cred c)
        {
            var i = repo.loginUser(c);
            if (i == false)
            {
                throw new UserNotFoundException();
            }
            else
            {
                return i;
            }


        }

        public int registerUser(Users u)
        {
            var p = repo.registerUser(u);
            if (p == 0)
            {//if no records added
                throw new UserAlreadyExistException();
            }
            else
            {
                return p;
                //true if repo.registerUser(u) == 1  
            }

        }
    }
}
