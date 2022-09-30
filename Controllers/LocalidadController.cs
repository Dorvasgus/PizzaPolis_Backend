using AutoMapper;
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
    public class LocalidadController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public LocalidadController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("paginacion")]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Localidad
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<LocalidadDTO>>(entidades);

                return Ok(new ResponseListDTO<LocalidadDTO>
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
        public async Task<ActionResult<LocalidadDTO>> Get(int id)
        {
            var localidad = await context.Localidad.FindAsync(id);

            var localidads = mapper.Map<LocalidadDTO>(localidad);

            return Ok(localidads);
        }
        [HttpPost(Name = "Insertar Localidad")]
        [Authorize(Roles = "CLI")]
        public async Task<ActionResult> Post([FromBody] LocalidadInsertarDTO insertarLocalidadDTO)
        {
            try
            {
                var localidad = mapper.Map<Localidad>(insertarLocalidadDTO);
                context.Localidad.Add(localidad);
                await context.SaveChangesAsync();
                return Ok("se guardo corectamente...");
            }
            catch (Exception ex)
            {

                return BadRequest(error: ex.Message);
            }

        }
        [HttpDelete]
        public async Task<int> deleteLocalidad(int LocalidadId)
        {
            var localidad = new Localidad { IdLocalidad = LocalidadId };
            context.Remove(localidad);
            await context.SaveChangesAsync();
            return localidad.IdLocalidad;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(LocalidadDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Localidad.Remove(new Localidad() { IdLocalidad = id });
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
