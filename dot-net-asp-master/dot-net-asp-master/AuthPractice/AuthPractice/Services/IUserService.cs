using AuthPractice.Model;

namespace AuthPractice.Services
{
    public interface IUserService
    {
        public int registerUser(Users u);
        public bool loginUser(Cred c);
    }
}
