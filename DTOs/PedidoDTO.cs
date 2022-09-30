using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class PedidoDTO
    {
        public PedidoDTO()
        {
            FacturaNavigation = new HashSet<FacturaDTO>();
        }

        public string Numero { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public DateTime? FechaHoraEntrega { get; set; }
        public int IdCliente { get; set; }
        public int Factura { get; set; }
        public int? Localidad { get; set; }
        public int? Detalle { get; set; }

        public virtual ICollection<FacturaDTO> FacturaNavigation { get; set; }
    }
}
