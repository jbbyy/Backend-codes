using AuthPractice.Model;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthPractice.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(Cred x)
        {
            var claim = new Claim[]
            {
                new Claim("email", x.email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this_is_my_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"authapi",
                audience:"movieapi",
                claims: claim , 
                expires: System.DateTime.Now.AddMinutes(20),
                signingCredentials: creds);

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
            };
            return JsonConvert.SerializeObject(response);

                
              

        }
    }
}
