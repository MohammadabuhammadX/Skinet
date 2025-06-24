using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        //we need a secure key that we can use to encrypt what we're goinh to use to sign this key from our server
        //this sigature is important because this is what allows our server to trust the token that the client sends back to us
        //the way that JWT token system works is we don't store anything in our database we generate a token form out server, our server is going to assgub this token with 

        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key; // this is the a type of encryption where only one key , secret key , which we're going to store in our server is used to both encrypt and decrypt our signature in the token so our security that key it's essential hat this never leaves our server otherwise anybody's going to be able to impersonate any user on our system 
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"])); // this is the key that we are going to use to sign our token, we are going to store it in our appsettings.json file
        }
        public string CreateToken(AppUser user)
        {
            var claums = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // this is the signature that we are going to use to sign our token, we are going to use the HMAC SHA512 algorithm to sign our token

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claums),
                Expires = DateTime.Now.AddDays(7), // this is the expiration date of our token, we are going to set it to 7 days
                SigningCredentials = creds, // this is the signature that we are going to use to sign our token
                Issuer = _config["Token:Issuer"], // this is the issuer of our token, we are going to set it to the value of the Token:Issuer key in our appsettings.json file
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); // this is the token that we are going to return to the client, we are going to use the WriteToken method of the JwtSecurityTokenHandler class to write the token to a string
        }
    }
}