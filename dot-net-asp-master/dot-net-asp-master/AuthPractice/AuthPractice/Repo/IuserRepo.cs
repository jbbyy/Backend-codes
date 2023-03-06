using AuthPractice.Model;

namespace AuthPractice.Repo
{
    public interface IuserRepo
    {
        public int registerUser(Users u);
        public bool loginUser(Cred c);
    }
}
