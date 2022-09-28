using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class ProductoDTO
    {
        public ProductoDTO()
        {
            DetallePedidos = new HashSet<DetallePedidoDTO>();
        }

        public string PizzaFamiliar { get; set; } = null!;
        public string PizzaMediana { get; set; } = null!;
        public string PizzaPequeña { get; set; } = null!;

        public virtual ICollection<DetallePedidoDTO> DetallePedidos { get; set; }
    }
}
