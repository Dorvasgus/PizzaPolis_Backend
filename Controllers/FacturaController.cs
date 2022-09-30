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
    public class FacturaController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public FacturaController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("paginacion")]

        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Cliente
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<FacturaDTO>>(entidades);

                return Ok(new ResponseListDTO<FacturaDTO>
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
        public async Task<ActionResult<List<FacturaDTO>>> Get(int id)
        {
            var factura = await context.Factura.FindAsync(id);

            var facturas = mapper.Map<List<FacturaDTO>>(factura);

            return Ok(facturas);
        }
        [HttpDelete]
        public async Task<int> deleteFactura(int FacturaId)
        {
            var factura = new Factura { IdFactura = FacturaId };
            context.Remove(factura);
            await context.SaveChangesAsync();
            return factura.IdFactura;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(FacturaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Factura.Remove(new Factura() { IdFactura = id });
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
