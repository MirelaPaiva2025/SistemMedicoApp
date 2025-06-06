using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Responses;

namespace SistemaMedicoApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoExamesController : ControllerBase
    {
        private readonly IPedidoExameService _pedidoExameService;

        public PedidoExamesController(IPedidoExameService pedidoExameService)
        {
            _pedidoExameService = pedidoExameService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidoExameResponseDto), 201)]
        public IActionResult Post([FromBody] PedidoExameRequestDto dto)
        {
            try
            {
                var response = _pedidoExameService.IncluirAsync(dto);
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
        [ProducesResponseType(typeof(PedidoExameResponseDto), 200)]
        public IActionResult Put(int id, [FromBody] PedidoExameRequestDto dto)
        {
            try
            {
                var response = _pedidoExameService.AlterarAsync(id, dto);
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
        [ProducesResponseType(typeof(PedidoExameResponseDto), 200)]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _pedidoExameService.ExcluirAsync(id);
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
        [ProducesResponseType(typeof(List<PedidoExameResponseDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _pedidoExameService.ConsultarAsync();

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
        [ProducesResponseType(typeof(PedidoExameResponseDto), 200)]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _pedidoExameService.ObterPorIdAsync(id);
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
