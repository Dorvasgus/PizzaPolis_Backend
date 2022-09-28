namespace PizzaPolis_01.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        public int cantidadRegistroPorPagina = 10;
        public int cantidadMaximaRegistrosPorPagina = 50;

        public int CantidadRegistroPorPagina
        {
            get => cantidadRegistroPorPagina;
            set
            {
                cantidadRegistroPorPagina = (value > cantidadMaximaRegistrosPorPagina) ? cantidadMaximaRegistrosPorPagina : value;
            }
        }
    }
}
