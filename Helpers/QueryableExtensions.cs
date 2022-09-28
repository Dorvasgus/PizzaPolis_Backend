using PizzaPolis_01.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PizzaPolis_01.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.CantidadRegistroPorPagina)
                .Take(paginacion.CantidadRegistroPorPagina);

        }
        public static async Task<Dictionary<string, string>> datosPaginacion<T>(this IQueryable<T> queryable, int cantidadRegistroPorPagina)
        {
            double cantidad = await queryable.CountAsync();
            double cantidadPagina = Math.Ceiling(cantidad / cantidadRegistroPorPagina);
            return new Dictionary<string, string>
            {
                { "CantidadPaginas", cantidadPagina.ToString() },
                { "TotalRegistros", cantidad.ToString() }
            };
        }
    }
}
