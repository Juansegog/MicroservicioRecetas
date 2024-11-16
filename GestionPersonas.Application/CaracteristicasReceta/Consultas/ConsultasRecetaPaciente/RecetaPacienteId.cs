using GestionRecetas.Application.Comunes;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente
{
    public class RecetaPacienteId : IRequest<RecetaVM>
    {
        public int PacienteId { get; set; }

        public RecetaPacienteId(int pacienteId)
        {
            PacienteId = pacienteId;
        }
    }
}
