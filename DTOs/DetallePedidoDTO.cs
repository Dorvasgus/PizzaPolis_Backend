using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class DetallePedidoDTO
    {
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }
        public int IdProducto { get; set; }
        public string Estado { get; set; }
        public int? IdPedido { get; set; }

        public virtual PedidoDTO IdPedidoNavigation { get; set; }
        public virtual ProductoDTO IdProductoNavigation { get; set; }
    }
}
