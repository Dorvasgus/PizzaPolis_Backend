using PizzaPolis_01.Models;
using System.ComponentModel.DataAnnotations;

namespace PizzaPolis_01.DTOs
{
    public class PersonaDTO
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string NumeroIdentidad { get; set; }
        public long Rol { get; set; }
        public int Telefono { get; set; }

       
    }
}
