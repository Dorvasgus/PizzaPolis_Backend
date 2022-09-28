using PizzaPolis_01.Models;

namespace PizzaPolis_01.DTOs
{
    public class UsuarioDTO
    {
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
        public int IdRol { get; set; }
        public byte[] Estado { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
