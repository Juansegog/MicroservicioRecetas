using GestionRecetas.Application.Comunes;
using GestionRecetas.Application.Contratos;
using GestionRecetas.Domain.Entities;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente
{
    public class ConsultaRecetaPacienteHandler : IRequestHandler<RecetaPacienteId, RecetaVM>
    {
        private readonly IRecetaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultaRecetaPacienteHandler(IRecetaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<RecetaVM> Handle(RecetaPacienteId request, CancellationToken cancellationToken)
        {
            var paciente = await _citaRepositorio.GetByIdAsync(request.PacienteId);
            RecetaVM resultadoPaciente = _genericMapperService.Map<Receta, RecetaVM>(paciente);
            return resultadoPaciente;
        }
    }
}
