using AutoMapper;
using PizzaPolis_01.DTOs;
using PizzaPolis_01.Models;

namespace PizzaPolis_01.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // mapeo general para las personas
            
            CreateMap< Persona, PersonaDTO>();
            // mapeo general para las vehiculo

            CreateMap<Vehiculo, VehiculoDTO>();

            CreateMap<Rol, RolDTO>();
        }
    }
}
