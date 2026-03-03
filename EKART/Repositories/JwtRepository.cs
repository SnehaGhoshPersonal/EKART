using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Core;
using EKART.Models;
using Microsoft.IdentityModel.Tokens;

namespace EKART.Repositories
{
    public class JwtRepository:IJwtRepository
    {
        private readonly EKARTContext _context;
        private readonly IConfiguration _configuration;
        public JwtRepository(EKARTContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Task<LoginResponse> Authenticate(LoginRequest loginRequest)
        {
            var accessToken = "";
            DateTime tokenExpireTimestamp= DateTime.Today;
            if (loginRequest.UserName.Equals("Sneha") && loginRequest.Password.Equals("12345")){
                var issuer = _configuration["jwt:Issuer"];
                var audience = _configuration["jwt:Audience"];
                var key=_configuration["jwt:Key"];
                var tokenValidityMins = _configuration.GetValue<int>("jwt:TokenValidityMins");
                tokenExpireTimestamp=DateTime.UtcNow.AddMinutes(tokenValidityMins);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, loginRequest.UserName),
                    }),
                    Expires = tokenExpireTimestamp,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature),
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken=tokenHandler.CreateToken(tokenDescriptor);
                accessToken=tokenHandler.WriteToken(securityToken);

           
            }
            return Task.FromResult(new LoginResponse
            {
                AccessToken = accessToken,
                UserName = loginRequest.UserName,
                ExpiresIn = (int)tokenExpireTimestamp.Subtract(DateTime.UtcNow).TotalSeconds
            });
        }
    }
}
