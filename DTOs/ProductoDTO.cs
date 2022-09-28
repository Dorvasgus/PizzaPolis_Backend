using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class ProductoDTO
    {
        public ProductoDTO()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        public int Id { get; set; }
        public string NombreProd { get; set; }
        public string DetalleProd { get; set; }
        public double PrecioProd { get; set; }

        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
