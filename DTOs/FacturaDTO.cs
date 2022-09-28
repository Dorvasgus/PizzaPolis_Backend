using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class FacturaDTO
    {
        public DateTime? FechaHoraEmision { get; set; }
        public string Detalle { get; set; }
        public string EstadodelPedido { get; set; }
        public string Nit { get; set; }
        public int? IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
