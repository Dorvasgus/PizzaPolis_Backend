﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PizzaPolis_01.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Cliente = new HashSet<Cliente>();
            Funcionario = new HashSet<Funcionario>();
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdRol { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Funcionario> Funcionario { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}