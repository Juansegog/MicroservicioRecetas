using GestionRecetas.Domain.Enums;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.PatchRecetaPaciente
{
    public class PatchRecetaPacienteCommand : IRequest<Unit>
    {
        public int Id { get; init; }
        public EstadoReceta EstadoReceta { get; init; }
        public PatchRecetaPacienteCommand(int id, EstadoReceta estadoActualCita)
        {
            Id = id;
            EstadoReceta = estadoActualCita;
        }
    }
}
