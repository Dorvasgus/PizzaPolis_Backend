// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PizzaPolis_01.Models
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroIdentidad { get; set; }
        public long Rol { get; set; }
        public int Telefono { get; set; }

        public virtual Funcionario IdPersonaNavigation { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}