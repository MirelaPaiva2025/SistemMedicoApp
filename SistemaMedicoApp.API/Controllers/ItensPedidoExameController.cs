using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Services;

namespace SistemaMedicoApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoExameController : ControllerBase
    {
        private readonly IItensPedidoExameService _itensPedidoExameService;

        public ItensPedidoExameController(IItensPedidoExameService itensPedidoExameService)
        {
            _itensPedidoExameService = itensPedidoExameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItensPedidoExameResponseDto), 201)]
        public IActionResult Post([FromBody] ItensPedidoExameRequestDto dto)
        {
            try
            {
                var response = _itensPedidoExameService.IncluirAsync(dto);
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
        [ProducesResponseType(typeof(ItensPedidoExameResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] ItensPedidoExameRequestDto dto)
        {
            try
            {
                var response = _itensPedidoExameService.AlterarAsync(id, dto);
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
        [ProducesResponseType(typeof(ItensPedidoExameResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _itensPedidoExameService.ExcluirAsync(id);
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
        [ProducesResponseType(typeof(List<ItensPedidoExameResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _itensPedidoExameService.ConsultarAsync();

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
        [ProducesResponseType(typeof(ItensPedidoExameResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _itensPedidoExameService.ObterPorIdAsync(id);
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
