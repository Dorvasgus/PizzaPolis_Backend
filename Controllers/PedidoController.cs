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
    public class PedidoController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public PedidoController(deliveryContext context, IMapper mapper)
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
                var list = mapper.Map<List<PedidoDTO>>(entidades);

                return Ok(new ResponseListDTO<PedidoDTO>
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
        public async Task<ActionResult<PedidoDTO>> Get(int id)
        {
            var pedido = await context.Pedido.FindAsync(id);

            var pedidos = mapper.Map<PedidoDTO>(pedido);

            return Ok(pedidos);
        }
        [HttpDelete]
        public async Task<int> deletePedido(int PedidoId)
        {
            var pedido = new Pedido { IdPedido = PedidoId };
            context.Remove(pedido);
            await context.SaveChangesAsync();
            return pedido.IdPedido;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(PedidoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Pedido.Remove(new Pedido() { IdPedido = id });
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
