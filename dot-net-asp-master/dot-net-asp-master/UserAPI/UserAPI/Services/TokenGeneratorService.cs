using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using UserAPI.Model;

namespace UserAPI.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {

        public string GenerateToken(Cred user)
        {
            //insert claim of token -username , email etc payload. whatever data we wish to pass via token
            //write claim object , used while generating token, have to be in form array
            var claim = new[]
            {
                //need key and value pair, store username form user.username
                new Claim("username", user.Username)
            };

            //create secret key, expects bytes 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This_is_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //predefined classes 
            //creating token
            var token = new JwtSecurityToken(
                issuer: "authapi",
                audience: "productapi",
                claims: claim,
                expires: System.DateTime.Now.AddMinutes(20),
                signingCredentials: creds
                );

            //need to send this token 
            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                //allow writing of token to response
            };
            return JsonConvert.SerializeObject(response);
                //need to install package Newtonsoft.json 

             
        }
    }
}
