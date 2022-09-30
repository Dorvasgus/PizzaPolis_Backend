using System.ComponentModel.DataAnnotations;

namespace PizzaPolis_01.DTOs
{
    public class ActualizarRolDTO
    {
        [Required]
        public int IdRol { get; set; }
        public string Alias { get; set; } = null!;
    }
}
