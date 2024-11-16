using GestionRecetas.Application.Comunes;
using MediatR;

namespace GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas
{
    public class GetAllRecetas : IRequest<List<RecetaVM>>
    {
    }
}
