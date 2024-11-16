using AutoMapper;
using GestionRecetas.Application.CaracteristicasCita.Commands.ComandoAddCita;
using GestionRecetas.Application.Comunes;
using GestionRecetas.Domain.Entities;

namespace GestionRecetas.Application.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Cita
            CreateMap<ComandoReceta, Receta>();
            CreateMap<Receta, ComandoReceta>().ReverseMap();
            CreateMap<Receta, RecetaVM>();
            CreateMap<RecetaVM, Receta>().ReverseMap();
            #endregion
        }
    }
}
