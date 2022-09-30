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
    public class RolController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public RolController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("paginacion")]
       // [Authorize(Roles = "ADM")]
        public async Task<ActionResult<List<RolDTO>>> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Rol
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<RolDTO>>(entidades);

                return Ok(new ResponseListDTO<RolDTO>
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
        [ProducesResponseType(typeof(RolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolDTO>>Get( int id)
        {
            try
            {
                var rol = await context.Rol.FindAsync( id);

                if (rol==null)
                {
                    return NotFound();
                }

                return Ok(rol);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();

            }
            
        }
        [HttpPost(Name = "Insertar Rol")]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult> Post([FromBody] InsertarRolDTO insertarRolDTO)
        {
            try
            {
                var rol = mapper.Map<Rol>(insertarRolDTO);
                context.Rol.Add(rol);
                await context.SaveChangesAsync();
                return Ok("se guardo corectamente...");
            }
            catch (Exception ex)
            {

                return BadRequest(error: ex.Message);
            }

        }
        [HttpDelete]
        [Authorize(Roles = "ADM")]
        public async Task<int> deleteRol(int RolID)
        {
            var rol = new Rol { IdRol = RolID };
            context.Remove(rol);
            await context.SaveChangesAsync();
            return rol.IdRol;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(RolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Rol.Remove(new Rol() { IdRol = id });
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
