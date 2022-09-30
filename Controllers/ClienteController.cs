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
    public class ClienteController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public ClienteController(deliveryContext context, IMapper mapper)
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
                var query = context.Cliente
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<ClienteDTO>>(entidades);

                return Ok(new ResponseListDTO<ClienteDTO>
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
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            var cliente = await context.Cliente.FindAsync(id);

            var clientes = mapper.Map<ClienteDTO>(cliente);

            return Ok(clientes);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] ClienteInsertarDTO creacionDTO)
        {
            try
            {
                var cliente = mapper.Map<Cliente>(creacionDTO);
                await context.Cliente.AddAsync(cliente);
                await context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete]
        [Authorize(Roles = "ADM")]
        [Authorize(Roles = "CLI")]
        public async Task<int> deleteCliente(int ClienteId)
        {
            var cliente = new Cliente { IdCliente = ClienteId };
            context.Remove(cliente);
            await context.SaveChangesAsync();
            return cliente.IdCliente;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Cliente.Remove(new Cliente() { IdCliente = id });
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
