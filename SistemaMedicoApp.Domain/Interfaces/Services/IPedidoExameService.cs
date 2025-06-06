using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Models.Responses;

namespace SistemaMedicoApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para o serviço de paciente.
    /// </summary>
    public interface IPedidoExameService
    {
        Task<PedidoExameResponseDto> IncluirAsync(PedidoExameRequestDto dto);
        Task<PedidoExameResponseDto> AlterarAsync(int id, PedidoExameRequestDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<List<PedidoExameResponseDto>> ConsultarAsync();
        Task<PedidoExameResponseDto> ObterPorIdAsync(int id);
    }
}
