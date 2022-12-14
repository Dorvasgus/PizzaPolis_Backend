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
        [ProducesResponseType(typeof(VehiculoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VehiculoDTO>> Get(int id)
        {
            try
            {
                var vehiculo = await context.Vehiculo.FindAsync(id);

                if (vehiculo == null)
                    return NotFound();
            var vehiculos = mapper.Map<VehiculoDTO>(vehiculo);

                return Ok(vehiculo);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();

            }

        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "ADM")]
        [ProducesResponseType(typeof(PutVehiculoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] PutVehiculoDTO PutVehiculoDTO)
        {
            try
            {
                var Vehiculo = await context.Vehiculo.FindAsync(id);

                if (Vehiculo == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                Vehiculo = mapper.Map(PutVehiculoDTO, Vehiculo);


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

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public async Task<ActionResult> Post([FromBody] InsertarVehiculoDTO insertVhDTO)
        {
            try
            {
                var vehiculo = mapper.Map<Vehiculo>(insertVhDTO);
                await context.Vehiculo.AddAsync(vehiculo);
                await context.SaveChangesAsync();
                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
