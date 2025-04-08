
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend_agendeFacil.src.model.tenant;
using Microsoft.IdentityModel.Tokens;

namespace backend_agendeFacil.src.services
{
    public class TokenService
    {
        public string GenerateToken(Tenant tenant)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Name, tenant.Email.ToString())
                ]),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}