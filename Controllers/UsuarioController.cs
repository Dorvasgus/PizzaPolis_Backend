using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Data;
using PizzaPolis_01.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaPolis_01.Helpers;

namespace PizzaPolis_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UsuarioController(deliveryContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> Get(int id)
        {
            try
            {
                var usuario = await context.Usuario
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (usuario == null)
                    return NotFound("No existe el recurso");

                var usuarioDTO = mapper.Map<UsuarioDTO>(usuario);


                return Ok(usuarioDTO);



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO creacionDTO)
        {
            try
            {
                var usuario = mapper.Map<Usuario>(creacionDTO);
                usuario.Estado = true;
                usuario.Contraseña = Encrypt.GetSHA256(creacionDTO.Password);

                context.Usuario.Add(usuario);
                await context.SaveChangesAsync();

                var dtoLectura = mapper.Map<UsuarioDTO>(usuario);
                return new CreatedAtRouteResult("GetUsuario", new { id = usuario.Id }, dtoLectura);



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]

        public async Task<ActionResult<UserToken>> Login([FromBody] UsuarioLoginDTO loginDTO)
        {
            try
            {
                var pass = Encrypt.GetSHA256(loginDTO.Password);

                var usuario = await context.Usuario
                    .FirstOrDefaultAsync(x => x.Usuario1 == loginDTO.UserName && x.Contraseña == pass && x.Estado);
                if (usuario == null)
                    return BadRequest("El usuario ò contraseña ingresada son incorrectas");

                var userdto = mapper.Map<UsuarioDTO>(usuario);

                var token = ConstruirToken(userdto);


                return Ok(token);




            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        private UserToken ConstruirToken(UsuarioDTO usuario)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario.Usuario1),

            };

            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddDays(2);

            JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiracion,
                    signingCredentials: creds);


            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion,
            };

        }
    }
}
