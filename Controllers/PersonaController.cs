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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [HttpGet("paginacion")]

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
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDTO>> Get(int id)
        {
            try
            {
                var persona = await context.Persona.FindAsync(id);

                if (persona == null)
                    return NotFound();

                return Ok(persona);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();

            }

        }
        [HttpPost(Name = "Insertar Persona")]
        [Authorize(Roles = "ADM")]
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

        [HttpPut("{id:int}")]
        // [Authorize(Roles = "ADM")]
        [ProducesResponseType(typeof(PutPersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] PutPersonaDTO PutPersonaDTO)
        {
            try
            {
                var Persona = await context.Persona.FindAsync(id);

                if (Persona == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                Persona = mapper.Map(PutPersonaDTO, Persona);


                // context.Entry(autor).State = EntityState.Modified;
                await context.SaveChangesAsync();


                //return NoContent();
                return Ok("DATOS ACTUALIZADOS CON EXITO");


            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
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

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Persona.Remove(new Persona() { IdPersona = id });
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }
    }
}
