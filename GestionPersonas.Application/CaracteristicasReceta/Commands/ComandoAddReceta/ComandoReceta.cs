using GestionRecetas.Application.Comunes;
using GestionRecetas.Domain.Enums;
using GestionRecetas.Domain.ValueObjects;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Commands.ComandoAddCita
{
    public class ComandoReceta : IRequest<RecetaVM>
    {
        public int PacienteId { get; init; }
        public string NombrePaciente { get; init; }
        public int Medico { get; set; }
        public string NombreMedico { get; init; }
        public string HistoriaClinica { get; init; }
        public string Dosis { get; init; }
        public string Duracion { get; init; }
        public string Instrucciones { get; init; }
        public string Medicamento { get; init; }
        public ViaAdministracion ViaAdministracion { get; init; }
        public EstadoReceta EstadoReceta { get; set; }
        public string ObservacionesPlanTratamiento { get; init; }
        public string Diagnostico { get; init; }
        public DateTime? FechaReceta { get; init; }
        public DateTime? FechaVencimiento { get; init; }
        public Direccion DireccionReclamacion { get; init; }
    }
}
