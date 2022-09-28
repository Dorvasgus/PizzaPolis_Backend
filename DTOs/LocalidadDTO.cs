using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class LocalidadDTO
    {
        public LocalidadDTO()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdLocalidad { get; set; }
        public string Calle { get; set; }
        public string Barrio { get; set; }
        public string Zona { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
