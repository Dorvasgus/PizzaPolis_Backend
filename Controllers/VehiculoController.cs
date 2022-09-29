using AutoMapper;
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
    public class VehiculoController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public VehiculoController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet ("Paginacion")]

        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Vehiculo
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<VehiculoDTO>>(entidades);

                return Ok(new ResponseListDTO<VehiculoDTO>
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
        public async Task<ActionResult<List<VehiculoDTO>>> Get(int id)
        {
            var vehiculo = await context.Vehiculo.FindAsync(id);

            var vehiculos = mapper.Map<List<VehiculoDTO>>(vehiculo);

            return Ok(vehiculos);
        }
        [HttpDelete]
        public async Task<int> deleteVehiculo(int VehiculoID)
        {
            var vehiculo = new Vehiculo { IdVehiculo = VehiculoID };
            context.Remove(vehiculo);
            await context.SaveChangesAsync();
            return vehiculo.IdVehiculo;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(VehiculoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Vehiculo.Remove(new Vehiculo() { IdVehiculo = id });
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
