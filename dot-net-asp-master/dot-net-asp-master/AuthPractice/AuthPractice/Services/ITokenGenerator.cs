using AuthPractice.Model;

namespace AuthPractice.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(Cred x);
    }
}
