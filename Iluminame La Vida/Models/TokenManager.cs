using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Iluminame_La_Vida.Models
{
    public class TokenManager
    {
        //Insertar una calve secreta SIN CARACTERES ESPECIALES y que sean 64 digitos.
        private string Secret = "4c2adnvdff2610443a5477834ce698b5ee643b84274e751612940d641401fbc7";
        //Metodo para generar el token Utomaticamente
        public string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                //Configurar el tiempo de vencimiento del Token.
                Expires = DateTime.UtcNow.AddMinutes(45),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler hendler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = hendler.CreateJwtSecurityToken(descriptor);
            return hendler.WriteToken(token);
        }

        public ClaimsPrincipal Get(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)handler.ReadJwtToken(token);
                if (jwtToken == null) return null;

                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    //Configurar Validaciones y Requerimientos
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ValidateToken(string token)
        {
            ClaimsPrincipal principal = Get(token);
            if (principal == null)
            { 
                return false; 
            }
            else
            {
                return true;
            }
        }
    }
}
