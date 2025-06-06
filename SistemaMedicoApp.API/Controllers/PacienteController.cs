using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Requests;

namespace SistemaMedicoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
     
        [HttpPost]
        [ProducesResponseType(typeof(PacienteResponseDto), 201)]
        public IActionResult Post([FromBody] PacienteRequestDto dto)
        {
            try
            {
                var response = _pacienteService.IncluirAsync(dto);
                return StatusCode(201, response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PacienteResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] PacienteRequestDto dto)
        {
            try
            {
                var response = _pacienteService.AlterarAsync(id, dto);
                return StatusCode(200, response);
            }
            catch (ValidationException e)
            {
                var errors = e.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PacienteResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _pacienteService.ExcluirAsync(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PacienteResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _pacienteService.ConsultarAsync();

                if (response != null && response.Any())
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204, new { message = "Nenhum paciente encontrado." });
                }
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PacienteResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _pacienteService.ObterPorIdAsync(id);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
