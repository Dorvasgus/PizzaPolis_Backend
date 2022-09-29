using Microsoft.IdentityModel.Tokens;
using PizzaPolis_01.Configuration.Contract;
using PizzaPolis_01.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaPolis_01.Configuration.Security
{
    public class JwtGenerador : IJwt
    {
        public string creartoken(UsuarioDTO usuario)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,usuario.Usuario1)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescripcion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires= DateTime.Now.AddMinutes(60),
                SigningCredentials = credenciales
            };

            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescripcion);
            
            return tokenManejador.WriteToken(token);
        }
    }
}
