using GestionRecetas.Domain.Enums;
using GestionRecetas.Domain.ValueObjects;

namespace GestionRecetas.Domain.Entities
{
    public class Receta
    {
        public int Id { get; private set; }
        public int PacienteId { get; private set; }
        public string NombrePaciente { get; private set; }
        public int Medico { get; set; }
        public string NombreMedico { get; private set; }
        public string HistoriaClinica { get; private set; }
        public string Dosis { get; private set; }
        public string Duracion { get; private set; }
        public string Instrucciones { get; private set; }
        public string Medicamento { get; private set; }
        public ViaAdministracion ViaAdministracion { get; private set; }
        public EstadoReceta EstadoReceta { get; set; }
        public string ObservacionesPlanTratamiento { get; private set; }
        public string Diagnostico { get; private set; }
        public DateTime? FechaReceta { get; private set; }
        public DateTime? FechaVencimiento { get; private set; }
        public Direccion DireccionReclamacion { get; private set; }


        private Receta()
        {

        }

        private Receta(int pacienteId, string nombrePaciente, int medico, string nombreMedico, string historiaClinica, string dosis, string duracion, string instrucciones, string medicamento, ViaAdministracion viaAdministracion, string observacionesPlanTratamiento, string diagnostico, DateTime fechaReceta, DateTime fechaVencimiento)
        {
            PacienteId = pacienteId;
            NombrePaciente = nombrePaciente;
            Medico = medico;
            NombreMedico = nombreMedico;
            HistoriaClinica = historiaClinica;
            Dosis = dosis;
            Duracion = duracion;
            Instrucciones = instrucciones;
            Medicamento = medicamento;
            ViaAdministracion = viaAdministracion;
            ObservacionesPlanTratamiento = observacionesPlanTratamiento;
            Diagnostico = diagnostico;
            FechaReceta = fechaReceta;
            FechaVencimiento = fechaVencimiento;
        }

        public static Receta CrearReceta(int PacienteId, string NombrePaciente, int Medico, string NombreMedico
                                    , string HistoriaClinica, string Dosis, string Duracion, string Instrucciones
                                    , string Medicamento, ViaAdministracion ViaAdministracion, string ObservacionesPlanTratamiento
                                    , string Diagnostico, DateTime FechaReceta, DateTime FechaVencimiento)
        {
            return new Receta(PacienteId, NombrePaciente, Medico, NombreMedico
                                     , HistoriaClinica, Dosis, Duracion, Instrucciones
                                     , Medicamento, ViaAdministracion, ObservacionesPlanTratamiento
                                     , Diagnostico, FechaReceta, FechaVencimiento);
        }

        public void CambiarEstado(EstadoReceta nuevoEstado)
        {
            if (nuevoEstado == null)
                throw new ArgumentException("El nuevo estado no puede ser nulo", nameof(nuevoEstado));

            EstadoReceta = nuevoEstado;
        }
    }
}
