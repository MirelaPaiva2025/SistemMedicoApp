using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Requests;

namespace SistemaMedicoApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private readonly IExameService _exameService;

        public ExameController(IExameService exameService)
        {
            _exameService = exameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExameResponseDto), 201)]
        public IActionResult Post([FromBody] ExameRequestDto dto)
        {
            try
            {
                var response = _exameService.IncluirAsync(dto);
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
        [ProducesResponseType(typeof(ExameResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] ExameRequestDto dto)
        {
            try
            {
                var response = _exameService.AlterarAsync(id, dto);
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
        [ProducesResponseType(typeof(ExameResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _exameService.ExcluirAsync(id);
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
        [ProducesResponseType(typeof(List<ExameResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _exameService.ConsultarAsync();

                if (response != null && response.Any())
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204, new { message = "Nenhum exame encontrado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExameResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _exameService.ObterPorIdAsync(id);
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
