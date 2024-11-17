using GestionRecetas.Application.CaracteristicasCita.Commands.ComandoAddCita;
using GestionRecetas.Application.CaracteristicasCita.Commands.ComandoPatchCita;
using GestionRecetas.Application.CaracteristicasCita.Commands.PatchRecetaPaciente;
using GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas;
using GestionRecetas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente;
using GestionRecetas.Application.Comunes;
using GestionRecetas.Domain.Enums;
using GestionRecetas.Domain.ExcepcionesGenerales;
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
            try
            {
                var result = await _mediator.Send(cita);
                return result;
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }


        [HttpGet("GetRecetaPaciente")]
        public async Task<ActionResult<RecetaVM>> GetRecetaPaciente(int pacienteId)
        {
            try
            {
                var query = new RecetaPacienteId(pacienteId);
                var result = await _mediator.Send(query);
                return result;
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }


        [HttpPatch("PatchEstadoReceta")]
        public async Task<ActionResult> PatchEstadoReceta(int IdReceta, EstadoReceta estadoReceta)
        {
            try
            {
                var query = new PatchRecetaCommand(IdReceta, estadoReceta);
                await _mediator.Send(query);
                return Ok();
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

        [HttpPatch("PatchEstRecePaciente")]
        public async Task<ActionResult> PatchEstRecePaciente(int IdPaciente, EstadoReceta estadoReceta)
        {
            try
            {
                var query = new PatchRecetaPacienteCommand(IdPaciente, estadoReceta);
                await _mediator.Send(query);
                return Ok();
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

        [HttpGet("GetAllRecetas")]
        public async Task<ActionResult<List<RecetaVM>>> GetAllCitas()
        {
            try
            {
                var query = new GetAllRecetas();
                var respPaciente = await _mediator.Send(query);
                return respPaciente;
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

    }
}
