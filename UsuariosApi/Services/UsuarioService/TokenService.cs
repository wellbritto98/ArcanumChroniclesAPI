using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Data.Dtos.CharacterDto;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string GenerateToken(UsuariosApi.Models.Usuario usuario)
        {
            var secretKey = _configuration["JwtConfig:Secret"];
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Role)


            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken
                (
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: signingCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
        

        public bool VerificaSeTokenJWTEValido(string token)
        {
            var secretKey = _configuration["JwtConfig:Secret"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = chave,
                    ValidateIssuer = false, // Considere mudar para true se aplicável
                    ValidateAudience = false // Considere mudar para true se aplicável
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}