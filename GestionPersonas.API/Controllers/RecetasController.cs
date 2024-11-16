using GestionRecetas.Application.CaracteristicasCita.Commands.ComandoAddCita;
using GestionRecetas.Application.CaracteristicasCita.Commands.ComandoPatchCita;
using GestionRecetas.Application.CaracteristicasCita.Commands.PatchRecetaPaciente;
using GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas;
using GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente;
using GestionRecetas.Application.Comunes;
using GestionRecetas.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionRecetas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecetasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostCrearReceta")]
        public async Task<ActionResult<RecetaVM>> PostCrearReceta([FromBody] ComandoReceta cita)
        {
            var result = await _mediator.Send(cita);
            return result;
        }


        [HttpGet("GetRecetaPaciente")]
        public async Task<ActionResult<RecetaVM>> GetRecetaPaciente(int pacienteId)
        {
            var query = new RecetaPacienteId(pacienteId);
            var result = await _mediator.Send(query);
            return result;
        }


        [HttpPatch("PatchEstadoReceta")]
        public async Task<ActionResult> PatchEstadoReceta(int IdReceta, EstadoReceta estadoReceta)
        {
            var query = new PatchRecetaCommand(IdReceta, estadoReceta);
            await _mediator.Send(query);
            return Ok();
        }

        [HttpPatch("PatchEstRecePaciente")]
        public async Task<ActionResult> PatchEstRecePaciente(int IdPaciente, EstadoReceta estadoReceta)
        {
            var query = new PatchRecetaPacienteCommand(IdPaciente, estadoReceta);
            await _mediator.Send(query);
            return Ok();
        }

        [HttpGet("GetAllRecetas")]
        public async Task<ActionResult<List<RecetaVM>>> GetAllCitas()
        {
            var query = new GetAllRecetas();
            var respPaciente = await _mediator.Send(query);
            return respPaciente;
        }

    }
}
