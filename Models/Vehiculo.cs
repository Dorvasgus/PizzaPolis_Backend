﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PizzaPolis_01.Models
{
    public partial class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Patente { get; set; }
        public string Modelo { get; set; }
        public int TipoVehiculo { get; set; }
        public string Licencia { get; set; }
        public int? IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual TipoVehiculo TipoVehiculoNavigation { get; set; }
    }
}