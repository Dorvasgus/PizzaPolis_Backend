﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PizzaPolis_01.Models
{
    public partial class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Correo { get; set; }
        public int IdUsuario { get; set; }
        public int? Vehiculo { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual Persona Persona { get; set; }
    }
}