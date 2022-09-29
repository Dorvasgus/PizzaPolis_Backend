using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPolis_01.Data;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Helpers;
using PizzaPolis_01.Models;

namespace PizzaPolis_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonaController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public PersonaController(deliveryContext context, IMapper mapper, IConfiguration configuration)
        {
            this.context = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        [HttpGet]

        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Persona
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<PersonaDTO>>(entidades);

                return Ok(new ResponseListDTO<PersonaDTO>
                {
                    cantidad = int.Parse(datosPaginacion["CantidadPaginas"]),
                    pagina = paginacion.Pagina,
                    total = int.Parse(datosPaginacion["TotalRegistros"]),
                    valores = list
                });
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }
        [HttpPost(Name = "Insertar Persona")]
        public async Task<ActionResult> Post([FromBody] PersonaInsertarDTO insertarPersonDTO)
        {
            try
            {
                var persona = mapper.Map<Persona>(insertarPersonDTO);
                context.Persona.Add(persona);
                await context.SaveChangesAsync();
                return Ok("se guardo corectamente...");
               
            }
            catch (Exception ex)
            {

                return BadRequest(error: ex.Message);
            }

        }
        [HttpDelete]
        public async Task<int> deletePersona(int PersonId)
        {
            var persona = new Persona { IdPersona = PersonId };
            context.Remove(persona);
            await context.SaveChangesAsync();
            return persona.IdPersona;

        }
    }
}
