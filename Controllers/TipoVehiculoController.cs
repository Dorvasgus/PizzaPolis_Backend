using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPolis_01.Data;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Helpers;
using PizzaPolis_01.Models;
using System.Data;

namespace PizzaPolis_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public TipoVehiculoController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet ("paginacion") ]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.TipoVehiculo
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<TipoVehiculoDTO>>(entidades);

                return Ok(new ResponseListDTO<TipoVehiculoDTO>
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
        public async Task<ActionResult<List<TipoVehiculoDTO>>> Get(int id)
        {
            var tipoVehiculo = await context.TipoVehiculo.FindAsync(id);

            var tipoVehiculos = mapper.Map<List<TipoVehiculoDTO>>(tipoVehiculo);

            return Ok(tipoVehiculos);
        }

        [HttpPost(Name = "Insertar Tipo Vehiculo")]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult> Post([FromBody] insertarTipoVehiculoDTO insertarTipoVehiculoDTO)
        {
            try
            {
                var tipoVehiculo = mapper.Map<TipoVehiculo>(insertarTipoVehiculoDTO);
                context.TipoVehiculo.Add(tipoVehiculo);
                await context.SaveChangesAsync();
                return Ok("se guardo corectamente...");
            }
            catch (Exception ex)
            {

                return BadRequest(error: ex.Message);
            }

        }

        [HttpDelete]
        public async Task<int> deleteTipoVehiculo(int TipoVehiculoID)
        {
            var Tvehiculo = new TipoVehiculo { IdTipoVehi = TipoVehiculoID };
            context.Remove(Tvehiculo);
            await context.SaveChangesAsync();
            return Tvehiculo.IdTipoVehi;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(TipoVehiculoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.TipoVehiculo.Remove(new TipoVehiculo() { IdTipoVehi = id });
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
