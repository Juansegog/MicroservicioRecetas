using GestionRecetas.Application.Comunes;
using GestionRecetas.Application.Contratos;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas
{
    public class ConsultaAllRecetasHandler : IRequestHandler<GetAllRecetas, List<RecetaVM>>
    {
        private readonly IRecetaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultaAllRecetasHandler(IRecetaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<List<RecetaVM>> Handle(GetAllRecetas request, CancellationToken cancellationToken)
        {
            var lstCitas = await _citaRepositorio.GetAllAsync();
            var entityObjects = lstCitas.Cast<object>().ToList();
            return _genericMapperService.MapListFromObject<RecetaVM>(entityObjects);
        }
    }
}
