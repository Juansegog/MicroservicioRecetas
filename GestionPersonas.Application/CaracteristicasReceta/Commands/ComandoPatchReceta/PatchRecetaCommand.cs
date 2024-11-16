using GestionRecetas.Domain.Enums;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.ComandoPatchCita
{
    public class PatchRecetaCommand : IRequest<Unit>
    {
        public int Id { get; init; }
        public EstadoReceta EstadoReceta { get; init; }
        public PatchRecetaCommand(int id, EstadoReceta estadoActualCita)
        {
            Id = id;
            EstadoReceta = estadoActualCita;
        }
    }
}
