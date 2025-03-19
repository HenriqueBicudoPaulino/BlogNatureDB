using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BlogNatureDB.Entities;

namespace BlogNatureDB.Services
{
    public class TokenService
    {
        private const string SecretKey = "sua_chave_secreta_super_segura"; // Altere para algo seguro
        private const int ExpirationMinutes = 60; // Token válido por 1 hora

        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.UserName),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("Nome", usuario.Nome),
                    new Claim("Sobrenome", usuario.Sobrenome),
                    new Claim("Telefone", usuario.Telefone),
                    new Claim(ClaimTypes.Role, usuario.NivelAcesso.ToString()) // Define o nível de acesso como role
                }),
                Expires = DateTime.UtcNow.AddMinutes(ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
