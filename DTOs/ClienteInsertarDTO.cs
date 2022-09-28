using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class ClienteInsertarDTO
    {
       

        public int IdCliente { get; set; }
        public string Nit { get; set; }
        public int IdRol { get; set; }

        public virtual Persona IdClienteNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
