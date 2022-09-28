using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class PedidoDTO
    {
        public string Numero { get; set; } = null!;
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraEntrega { get; set; }
        public string Calle { get; set; } = null!;
        public int Persona { get; set; }
        public int Factura { get; set; }
        public int Localidad { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int TelefonoCliente { get; set; }
        public int Detalle { get; set; }

        public virtual FacturaDTO FacturaNavigation { get; set; } = null!;
        public virtual DetallePedidoDTO IdPedidoNavigation { get; set; } = null!;
        public virtual LocalidadDTO LocalidadNavigation { get; set; } = null!;
        public virtual PersonaDTO PersonaNavigation { get; set; } = null!;
    }
}
