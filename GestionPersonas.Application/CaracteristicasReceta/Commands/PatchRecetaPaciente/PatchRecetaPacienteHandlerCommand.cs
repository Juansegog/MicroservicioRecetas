using GestionRecetas.Application.Contratos;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.PatchRecetaPaciente
{
    public class PatchRecetaPacienteHandlerCommand : IRequestHandler<PatchRecetaPacienteCommand, Unit>
    {
        private readonly IRecetaRepositorio _recetaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public PatchRecetaPacienteHandlerCommand(IRecetaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _recetaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<Unit> Handle(PatchRecetaPacienteCommand request, CancellationToken cancellationToken)
        {
            var RecetaPaciente = await _recetaRepositorio.GetByIdAsync(request.Id);
            RecetaPaciente.CambiarEstado(request.EstadoReceta);
            await _recetaRepositorio.UpdateAsync(RecetaPaciente);
            return Unit.Value;
        }
    }
}
