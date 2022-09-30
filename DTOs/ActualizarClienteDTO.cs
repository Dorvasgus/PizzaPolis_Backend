using System.ComponentModel.DataAnnotations;

namespace PizzaPolis_01.DTOs
{
    public class ActualizarClienteDTO
    {
        
        //public int IdCliente { get; set; }
        public string Nit { get; set; } = null!;
        public int IdRol { get; set; }
    }
}
