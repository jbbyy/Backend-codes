using UserAPI.Model;

namespace UserAPI.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(Cred user);
    }
}
