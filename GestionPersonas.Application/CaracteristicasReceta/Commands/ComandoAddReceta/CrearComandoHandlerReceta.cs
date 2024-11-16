using GestionRecetas.Application.Comunes;
using GestionRecetas.Application.Contratos;
using GestionRecetas.Domain.Entities;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.ComandoAddCita
{

    public class CrearComandoHandlerReceta : IRequestHandler<ComandoReceta, RecetaVM>
    {

        private readonly IRecetaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;

        public CrearComandoHandlerReceta(IRecetaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<RecetaVM> Handle(ComandoReceta request, CancellationToken cancellationToken)
        {
            var MapReceta = _genericMapperService.Map<ComandoReceta, Receta>(request);
            var recetaInsertada = await _citaRepositorio.AddAsync(MapReceta);
            var resultado = _genericMapperService.Map<Receta, RecetaVM>(recetaInsertada);
            return resultado;
        }
    }
}
