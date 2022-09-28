using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPolis_01.Data;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Helpers;

namespace PizzaPolis_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public PersonaController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
    }
}
