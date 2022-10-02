//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PizzaPolis_01.Data;
//using PizzaPolis_01.DTOs;
//using PizzaPolis_01.Helpers;
//using PizzaPolis_01.Models;

//namespace PizzaPolis_01.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductoController : ControllerBase
//    {
//        private readonly deliveryContext context;
//        private readonly IMapper mapper;
//        public ProductoController(deliveryContext context, IMapper mapper)
//        {
//            this.context = context;
//            this.mapper = mapper;
//        }
//        [HttpGet("paginacion")]

//        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
//        {
//            try
//            {
//                var query = context.Productos
//                .AsQueryable();

//                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
//                var entidades = await query.Paginar(paginacion).ToListAsync();
//                var list = mapper.Map<List<ProductoDTO>>(entidades);

//                return Ok(new ResponseListDTO<ProductoDTO>
//                {
//                    cantidad = int.Parse(datosPaginacion["CantidadPaginas"]),
//                    pagina = paginacion.Pagina,
//                    total = int.Parse(datosPaginacion["TotalRegistros"]),
//                    valores = list
//                });
//            }
//            catch (Exception ex)
//            {

//                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
//            }
//        }
//        [HttpGet("{id:int}")]
//        [ProducesResponseType(typeof(ProductoDTO), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<ProductoDTO>> Get(int id)
//        {
//            try
//            {
//                var productos = await context.Productos.FindAsync(id);

//                if (productos == null)
//                    return NotFound();
//            var productos1 = mapper.Map<ProductoDTO>(productos);

//                return Ok(productos);
//            }
//            catch (Exception ex)
//            {

//                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();

//            }

//        }
//        [HttpDelete]
//        public async Task<int> deleteProducto(int productoId)
//        {
//            var productos = new Productos { Id = productoId };
//            context.Remove(productos);
//            await context.SaveChangesAsync();
//            return productos.Id;

//        }

//        [HttpDelete("{id:int}")]
//        [ProducesResponseType(typeof(ProductoDTO), StatusCodes.Status200OK)]
//        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult> Delete(int id)
//        {
//            try
//            {
//                context.Productos.Remove(new Productos() { Id = id });
//                await context.SaveChangesAsync();
//                return NoContent();

//            }
//            catch (Exception ex)
//            {
//                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
//            }
//        }
//    }
//}

﻿using AutoMapper;
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
    public class ProductoController : ControllerBase
    {
        private readonly deliveryContext context;
        private readonly IMapper mapper;
        public ProductoController(deliveryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult> Get([FromQuery] PaginacionDTO paginacion)
        {
            try
            {
                var query = context.Productos
                .AsQueryable();

                var datosPaginacion = await query.datosPaginacion(paginacion.cantidadRegistroPorPagina);
                var entidades = await query.Paginar(paginacion).ToListAsync();
                var list = mapper.Map<List<ProductoDTO>>(entidades);

                return Ok(new ResponseListDTO<ProductoDTO>
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
        [ProducesResponseType(typeof(ProductoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            try
            {
                var productos = await context.Productos.FindAsync(id);

                if (productos == null)
                    return NotFound();

                return Ok(productos);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();

            }

        }
        [HttpDelete]
        public async Task<int> deleteProducto(int productoId)
        {
            var productos = new Productos { Id = productoId };
            context.Remove(productos);
            await context.SaveChangesAsync();
            return productos.Id;

        }

        [HttpPut("{id:int}")]
        // [Authorize(Roles = "ADM")]
        [ProducesResponseType(typeof(PutProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] PutProducto PutProducto)
        {
            try
            {
                var Productos = await context.Productos.FindAsync(id);

                if (Productos == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                Productos = mapper.Map(PutProducto, Productos);


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
        //[Authorize(Roles = "ADM")]
        public async Task<ActionResult> Post([FromBody] InsertarProductoDTO insertPDTO)
        {
            try
            {
                var producto = mapper.Map<Productos>(insertPDTO);
                await context.Productos.AddAsync(producto);
                await context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(ProductoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Productos.Remove(new Productos() { Id = id });
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
