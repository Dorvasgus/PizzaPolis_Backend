﻿using AutoMapper;
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
    public class RolController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public RolController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
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
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolDTO insertarRolDTO)
        {
            try
            {
                var rol = mapper.Map<RolDTO>(insertarRolDTO);
                //context.Rol.Add(rol);
                await context.SaveChangesAsync();

                /////
                var dtoLectura = mapper.Map<RolDTO>(rol);
                return new CreatedAtRouteResult("getAutor", new { id = rol.IdRol }, dtoLectura);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}