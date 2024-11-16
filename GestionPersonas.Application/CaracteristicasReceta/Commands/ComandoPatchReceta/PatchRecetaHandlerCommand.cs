using GestionRecetas.Application.Contratos;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.ComandoPatchCita
{
    public class PatchRecetaHandlerCommand : IRequestHandler<PatchRecetaCommand, Unit>
    {
        private readonly IRecetaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public PatchRecetaHandlerCommand(IRecetaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<Unit> Handle(PatchRecetaCommand request, CancellationToken cancellationToken)
        {
            var cita = await _citaRepositorio.GetByIdAsync(request.Id);
            cita.CambiarEstado(request.EstadoReceta);
            await _citaRepositorio.UpdateAsync(cita);
            return Unit.Value;
        }
    }
}
